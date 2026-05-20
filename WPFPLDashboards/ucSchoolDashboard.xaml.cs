using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DVLDBussinessLayer;

namespace WPFPLDashboards
{
    public partial class ucSchoolDashboard : UserControl
    {
        private int _instituteID;
        private clsSchoolDashboardStats _stats;

        // Custom events for communicating with the parent WinForms project
        public event EventHandler AttendanceClicked;
        public event EventHandler StudentsClicked;
        public event EventHandler ScheduleTestClicked;
        public event EventHandler CoursesClicked;

        public ucSchoolDashboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the dashboard for a specific institute and loads the data.
        /// </summary>
        public void InitializeDashboard(int instituteID)
        {
            _instituteID = instituteID;
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                // Load statistics from Business Layer
                _stats = clsSchoolDashboardStats.Load(_instituteID);

                // Populate KPI values
                txtTotalStudents.Text = _stats.TotalStudents.ToString("N0");
                txtNewStudents.Text = $"+{_stats.NewStudentsThisMonth} this month";
                txtActiveBatches.Text = _stats.ActiveBatches.ToString();
                txtWaitingList.Text = $"{_stats.WaitingList} in queue";
                txtAttendanceRate.Text = $"{_stats.TodayAttendanceRate}%";
                txtTotalEarnings.Text = _stats.TotalEarnings.ToString("C0");

                // Populate Pass Rates
                SetPassRate(progressVision, txtVisionRate, _stats.PassRateVision);
                SetPassRate(progressTheory, txtTheoryRate, _stats.PassRateTheory);
                SetPassRate(progressRoad, txtRoadRate, _stats.PassRateRoad);

                // Load Recent Students
                LoadRecentStudents();

                // Draw Chart
                DrawEnrollmentChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetPassRate(ProgressBar pb, TextBlock txt, int rate)
        {
            if (rate < 0)
            {
                pb.Value = 0;
                txt.Text = "No data";
            }
            else
            {
                pb.Value = Math.Min(rate, 100);
                txt.Text = $"{rate}%";
            }
        }

        private void LoadRecentStudents()
        {
            try
            {
                DataTable dt = clsEnrollment.GetAllByInstitute(_instituteID);
                
                // Take top 8 records
                DataTable top8 = dt.Clone();
                int max = Math.Min(8, dt.Rows.Count);
                for (int i = 0; i < max; i++)
                {
                    top8.ImportRow(dt.Rows[i]);
                }

                // Bind to Grid
                dgvRecentStudents.ItemsSource = top8.DefaultView;
            }
            catch
            {
                // Fallback silently if enrollment fails
            }
        }

        // Draw dynamic area chart using Canvas & Paths
        private void DrawEnrollmentChart()
        {
            if (ChartCanvas == null) return;
            ChartCanvas.Children.Clear();

            if (_stats?.MonthlyEnrollmentStats == null || _stats.MonthlyEnrollmentStats.Rows.Count == 0)
                return;

            DataTable dt = _stats.MonthlyEnrollmentStats;
            int count = dt.Rows.Count;

            double width = ChartCanvas.ActualWidth;
            double height = ChartCanvas.ActualHeight - 30; // space for month names
            double marginX = 40;

            if (width <= 0 || height <= 0) return;

            // Find Maximum value for scaling
            int maxVal = 5;
            foreach (DataRow row in dt.Rows)
            {
                maxVal = Math.Max(maxVal, Convert.ToInt32(row["Count"]));
            }
            maxVal = (int)(maxVal * 1.4); // Add 40% headroom

            // Generate control coordinates
            Point[] points = new Point[count];
            double stepX = (width - (marginX * 2)) / (count > 1 ? count - 1 : 1);

            // Draw grid lines and labels
            for (int i = 0; i < count; i++)
            {
                int val = Convert.ToInt32(dt.Rows[i]["Count"]);
                double x = marginX + (i * stepX);
                double y = height - (val * (height / maxVal));

                // Guard points within canvas bounds
                y = Math.Max(0, y);
                points[i] = new Point(x, y);

                // Add Month Label
                string month = dt.Rows[i]["MonthName"].ToString();
                TextBlock txtMonth = new TextBlock
                {
                    Text = month,
                    Foreground = new SolidColorBrush(Color.FromRgb(143, 146, 161)), // TextSecondary
                    FontSize = 10,
                    FontFamily = new FontFamily("Segoe UI"),
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Canvas.SetLeft(txtMonth, x - 15);
                Canvas.SetTop(txtMonth, height + 8);
                ChartCanvas.Children.Add(txtMonth);

                // Draw Vertical Gridline
                Line gridLine = new Line
                {
                    X1 = x,
                    Y1 = 0,
                    X2 = x,
                    Y2 = height,
                    Stroke = new SolidColorBrush(Color.FromArgb(20, 255, 255, 255)), // very faint white
                    StrokeThickness = 1
                };
                ChartCanvas.Children.Add(gridLine);
            }

            // Area path geometry
            if (count > 1)
            {
                // Create gradient fills
                LinearGradientBrush areaGradient = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(0, 1)
                };
                areaGradient.GradientStops.Add(new GradientStop(Color.FromArgb(80, 0, 242, 254), 0.0)); // Semi-transparent Cyan
                areaGradient.GradientStops.Add(new GradientStop(Color.FromArgb(5, 79, 172, 254), 1.0));  // Almost transparent Blue

                PathGeometry geometry = new PathGeometry();
                PathFigure figure = new PathFigure
                {
                    StartPoint = points[0],
                    IsClosed = false
                };

                // Draw smooth bezier curve through points
                for (int i = 0; i < count - 1; i++)
                {
                    Point p1 = points[i];
                    Point p2 = points[i + 1];
                    double controlX = p1.X + (p2.X - p1.X) / 2;
                    
                    BezierSegment bezier = new BezierSegment
                    {
                        Point1 = new Point(controlX, p1.Y),
                        Point2 = new Point(controlX, p2.Y),
                        Point3 = p2
                    };
                    figure.Segments.Add(bezier);
                }
                geometry.Figures.Add(figure);

                // Draw Line Path
                Path linePath = new Path
                {
                    Stroke = new LinearGradientBrush(Color.FromRgb(0, 242, 254), Color.FromRgb(79, 172, 254), 45), // Neon Cyan-Blue
                    StrokeThickness = 3,
                    Data = geometry
                };
                ChartCanvas.Children.Add(linePath);

                // Draw Area Path
                PathGeometry areaGeometry = geometry.Clone();
                PathFigure areaFigure = areaGeometry.Figures[0];
                areaFigure.IsClosed = true;
                areaFigure.Segments.Add(new LineSegment(points[count - 1] = new Point(points[count - 1].X, height), true));
                areaFigure.Segments.Add(new LineSegment(new Point(points[0].X, height), true));

                Path areaPath = new Path
                {
                    Fill = areaGradient,
                    Data = areaGeometry
                };
                ChartCanvas.Children.Add(areaPath);

                // Draw glow dots at vertices
                foreach (Point p in points)
                {
                    // Filter outer lower lines added to close the area shape
                    if (p.Y >= height) continue;

                    Ellipse dot = new Ellipse
                    {
                        Width = 8,
                        Height = 8,
                        Fill = new SolidColorBrush(Colors.White),
                        Stroke = new SolidColorBrush(Color.FromRgb(0, 242, 254)),
                        StrokeThickness = 2
                    };
                    Canvas.SetLeft(dot, p.X - 4);
                    Canvas.SetTop(dot, p.Y - 4);
                    ChartCanvas.Children.Add(dot);
                }
            }
        }

        private void ChartCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawEnrollmentChart();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadDashboardData();
        }

        // Raise events to notify the WinForms container when clicks happen
        private void btnAttendance_Click(object sender, RoutedEventArgs e)
        {
            AttendanceClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnStudents_Click(object sender, RoutedEventArgs e)
        {
            StudentsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnScheduleTest_Click(object sender, RoutedEventArgs e)
        {
            ScheduleTestClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnCourses_Click(object sender, RoutedEventArgs e)
        {
            CoursesClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
