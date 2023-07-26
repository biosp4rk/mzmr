using mzmr.UI;
using System;
using System.Windows.Forms;

namespace mzmr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        public const string Version = "1.5.0";

    }
}
