using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Register Pub/Sub Subscribers for test scheduling
            DVLDBussinessLayer.clsTestSchedulePublisher.Subscribe(new DVLDBussinessLayer.clsStudentMobileSubscriber());
            DVLDBussinessLayer.clsTestSchedulePublisher.Subscribe(new DVLDBussinessLayer.clsSchoolDashboardSubscriber());
            DVLDBussinessLayer.clsTestSchedulePublisher.Subscribe(new DVLDBussinessLayer.clsEmailSmtpSubscriber());

            // Temporarily changed from frmLogin() to frmSchoolDashboard() for testing
            Application.Run(new frmSchoolDashboard(1));
        }
    }
}
