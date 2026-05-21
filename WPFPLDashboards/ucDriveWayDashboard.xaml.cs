using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using DVLDBussinessLayer;

namespace WPFPLDashboards
{
    public partial class ucDriveWayDashboard : UserControl
    {
        private int _instituteID;
        private clsSchoolDashboardStats _stats;
        private List<StudentEnrollmentViewModel> _allStudents;

        // Custom events to notify WinForms host
        public event EventHandler StudentsClicked;
        public event EventHandler FleetClicked;

        public ucDriveWayDashboard()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            if (txtSearch != null)
            {
                txtSearch.TextChanged += txtSearch_TextChanged;
                txtSearch.GotFocus += txtSearch_GotFocus;
                txtSearch.LostFocus += txtSearch_LostFocus;
            }
            if (btnStudentsSidebar != null) btnStudentsSidebar.Click += btnStudentsSidebar_Click;
            if (btnFleetSidebar != null) btnFleetSidebar.Click += btnFleetSidebar_Click;
            if (btnStudentsViewDetails != null) btnStudentsViewDetails.Click += btnStudentsSidebar_Click;
            if (btnFleetStatus != null) btnFleetStatus.Click += btnFleetSidebar_Click;
            if (btnNewLesson != null) btnNewLesson.Click += btnNewLesson_Click;
        }

        public void InitializeDashboard(int instituteID)
        {
            _instituteID = instituteID;
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                // 1. Load Statistics
                _stats = clsSchoolDashboardStats.Load(_instituteID);

                txtTotalStudents.Text = _stats.TotalStudents.ToString("N0");
                txtTodayLessons.Text = _stats.TestsToday.ToString("N0"); // Or mocked

                // 2. Load Vehicles Catalog for Fleet
                DataTable dtVehicles = clsDriverVehicle.GetVehiclesCatalog();
                int totalVehicles = dtVehicles.Rows.Count;
                int activeVehicles = Math.Max(0, totalVehicles - 3); // Mock some in maintenance
                if (totalVehicles == 0) { totalVehicles = 25; activeVehicles = 22; }
                
                txtActiveVehicles.Text = $"{activeVehicles} / {totalVehicles}";
                double availability = totalVehicles > 0 ? (double)activeVehicles / totalVehicles * 100 : 0;
                txtAvailability.Text = $"{Math.Round(availability)}% availability";

                // 3. Load Student Enrollments
                LoadRecentEnrollments();

                // 4. Generate Weekly Schedule
                GenerateWeeklySchedule();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}");
            }
        }

        private void LoadRecentEnrollments()
        {
            DataTable dt = clsEnrollment.GetAllByInstitute(_instituteID);
            _allStudents = new List<StudentEnrollmentViewModel>();

            foreach (DataRow row in dt.Rows)
            {
                string fullName = row["FullName"].ToString();
                string initials = string.Join("", fullName.Split(' ').Take(2).Select(s => s.Length > 0 ? s[0].ToString() : ""));
                bool isActive = Convert.ToBoolean(row["IsActive"]);

                _allStudents.Add(new StudentEnrollmentViewModel
                {
                    FullName = fullName,
                    Initials = initials.ToUpper(),
                    EnrollmentDate = Convert.ToDateTime(row["EnrollmentDate"]),
                    CourseName = row["CourseName"].ToString(),
                    StatusText = isActive ? "Active" : "Pending",
                    StatusBgColor = isActive ? "#D1FAE5" : "#FEF3C7", // Green/Orange
                    StatusTextColor = isActive ? "#059669" : "#D97706"
                });
            }

            // Fallback if empty database
            if (_allStudents.Count == 0)
            {
                _allStudents.Add(new StudentEnrollmentViewModel { FullName = "Emily Johnson", Initials = "EJ", CourseName = "Standard", EnrollmentDate = DateTime.Now.AddDays(-2), StatusText = "Registered", StatusBgColor = "#DBEAFE", StatusTextColor = "#2563EB" });
                _allStudents.Add(new StudentEnrollmentViewModel { FullName = "Michael Brown", Initials = "MB", CourseName = "Intensive", EnrollmentDate = DateTime.Now.AddDays(-5), StatusText = "Active", StatusBgColor = "#D1FAE5", StatusTextColor = "#059669" });
                _allStudents.Add(new StudentEnrollmentViewModel { FullName = "Chloe Davis", Initials = "CD", CourseName = "Refresher", EnrollmentDate = DateTime.Now.AddDays(-10), StatusText = "Pending", StatusBgColor = "#FEF3C7", StatusTextColor = "#D97706" });
            }

            dgvRecentStudents.ItemsSource = _allStudents;
        }

        private void GenerateWeeklySchedule()
        {
            gridSchedule.Children.Clear();
            gridSchedule.RowDefinitions.Clear();
            gridSchedule.ColumnDefinitions.Clear();

            // 6 Columns: Time, Mon, Tue, Wed, Thu, Fri
            for (int i = 0; i < 6; i++)
            {
                gridSchedule.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            // Header Row + 5 Time Slots
            string[] times = { "09:00", "11:30", "14:00", "14:30", "16:00" };
            string[] days = { "Time", "Mon, Oct 23rd", "Tue, Oct 24th", "Wed, Oct 25th", "Thu, Oct 26th", "Fri, Oct 27th" };

            // Add Rows
            for (int i = 0; i <= times.Length; i++)
            {
                gridSchedule.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60) });
            }

            // Add Headers
            for (int c = 0; c < 6; c++)
            {
                Border b = new Border { BorderBrush = new SolidColorBrush(Color.FromRgb(226, 232, 240)), BorderThickness = new Thickness(0, 0, 1, 1), Background = new SolidColorBrush(Color.FromRgb(248, 250, 252)) };
                TextBlock t = new TextBlock { Text = days[c], FontWeight = FontWeights.SemiBold, Foreground = new SolidColorBrush(Color.FromRgb(100, 116, 139)), VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center, FontSize = 13 };
                b.Child = t;
                Grid.SetRow(b, 0); Grid.SetColumn(b, c);
                gridSchedule.Children.Add(b);
            }

            // Add Time Labels & Grid Lines
            for (int r = 1; r <= times.Length; r++)
            {
                Border timeBorder = new Border { BorderBrush = new SolidColorBrush(Color.FromRgb(226, 232, 240)), BorderThickness = new Thickness(0, 0, 1, 1) };
                TextBlock t = new TextBlock { Text = times[r - 1], Foreground = new SolidColorBrush(Color.FromRgb(100, 116, 139)), VerticalAlignment = VerticalAlignment.Top, HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(0, 10, 0, 0), FontSize = 12 };
                timeBorder.Child = t;
                Grid.SetRow(timeBorder, r); Grid.SetColumn(timeBorder, 0);
                gridSchedule.Children.Add(timeBorder);

                for (int c = 1; c < 6; c++)
                {
                    Border cell = new Border { BorderBrush = new SolidColorBrush(Color.FromRgb(226, 232, 240)), BorderThickness = new Thickness(0, 0, 1, 1) };
                    Grid.SetRow(cell, r); Grid.SetColumn(cell, c);
                    gridSchedule.Children.Add(cell);
                }
            }

            // Mock Schedule Cards
            AddScheduleCard(1, 1, "09:00\nLiam M.\nVW Golf", "#DBEAFE", "#1D4ED8", "#3B82F6"); // Blue
            AddScheduleCard(2, 2, "11:30\nSarah K.\nVW Golf", "#D1FAE5", "#047857", "#10B981"); // Green
            AddScheduleCard(1, 4, "Booked\nSarah K.\nVW Golf", "#FEE2E2", "#B91C1C", "#EF4444"); // Red
            AddScheduleCard(3, 2, "14:00\nBenna R.\nVW Golf", "#FEF3C7", "#B45309", "#F59E0B"); // Orange
            AddScheduleCard(4, 1, "Booked\nJessica R.\nVW Golf", "#FEE2E2", "#B91C1C", "#EF4444");
            AddScheduleCard(2, 3, "11:30\nEmily R.\nVW Golf", "#D1FAE5", "#047857", "#10B981");
        }

        private void AddScheduleCard(int row, int col, string text, string bgColor, string textColor, string leftBorderColor)
        {
            Border card = new Border
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(bgColor)),
                BorderThickness = new Thickness(4, 0, 0, 0),
                BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(leftBorderColor)),
                CornerRadius = new CornerRadius(4),
                Margin = new Thickness(4),
                Padding = new Thickness(8, 4, 8, 4),
                Cursor = Cursors.Hand
            };

            TextBlock t = new TextBlock
            {
                Text = text,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(textColor)),
                FontSize = 11,
                FontWeight = FontWeights.SemiBold,
                LineHeight = 14
            };

            card.Child = t;
            Grid.SetRow(card, row);
            Grid.SetColumn(card, col);
            gridSchedule.Children.Add(card);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_allStudents == null) return;
            string q = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(q) || q == "search students...")
            {
                dgvRecentStudents.ItemsSource = _allStudents;
                return;
            }

            var filtered = _allStudents.Where(s => 
                s.FullName.ToLower().Contains(q) || 
                s.CourseName.ToLower().Contains(q)).ToList();
            
            dgvRecentStudents.ItemsSource = filtered;
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "Search Students...")
                txtSearch.Text = "";
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                txtSearch.Text = "Search Students...";
        }

        private void btnStudentsSidebar_Click(object sender, RoutedEventArgs e)
        {
            StudentsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnFleetSidebar_Click(object sender, RoutedEventArgs e)
        {
            FleetClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnNewLesson_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New Lesson scheduling module opened!", "Schedule", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    public class StudentEnrollmentViewModel
    {
        public string FullName { get; set; }
        public string Initials { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string CourseName { get; set; }
        public string StatusText { get; set; }
        public string StatusBgColor { get; set; }
        public string StatusTextColor { get; set; }
    }
}
