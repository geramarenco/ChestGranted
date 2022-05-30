using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChestGrantedView
{
    static class Program
    {
        //[DllImport("user32.dll")]
        //public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
        //[DllImport("user32.dll")]
        //public static extern bool SetForegroundWindow(IntPtr WindowHandle);
        //public const int SW_RESTORE = 9;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var processName = "ChestGrantedView";
            //var processes = Process.GetProcessesByName(processName);
            //if (processes.Length > 0)
            //{
            //    // Is running
            //    //handle = processName[0].MainWindowHandle;
            //    //SetForegroundWindow(handle);

            //    IntPtr hWnd = IntPtr.Zero;
            //    hWnd = processes[0].MainWindowHandle;
            //    ShowWindowAsync(new HandleRef(null, hWnd), SW_RESTORE);
            //    SetForegroundWindow(processes[0].MainWindowHandle);
            //    return;
            //}

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
