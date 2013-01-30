using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InstantMessenger
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

			SharedClasses.AutoUpdating.CheckForUpdates_ExceptionHandler();

            Application.Run(new MainForm());
        }
    }
}
