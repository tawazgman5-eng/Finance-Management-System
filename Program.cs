using System;
using System.Windows.Forms;

namespace Finance_Management_Sys
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start the application with LoginForm
            Application.Run(new LoginForm());

        }
    }
}
