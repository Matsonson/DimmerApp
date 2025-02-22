﻿using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DimmerApp { 
    class WindowChecker
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public async Task<string> CheckActiveWindow()
        {
            while (true)
            {
                string activeWindowTitle = GetActiveWindowTitle();
                if (activeWindowTitle != null)
                {
                    Console.WriteLine(activeWindowTitle);
                }
                await Task.Delay(1000);
            }
        }
    }


}