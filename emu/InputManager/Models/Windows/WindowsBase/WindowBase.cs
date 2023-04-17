using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace emu.InputManager.Models.Windows.WindowsBase
{
    public abstract class WindowBase
    {
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

        public static Point ComputeLocalMousePosition(Point globalMousePoint)
        {
            Point localPoint = new Point();
            localPoint.X = globalMousePoint.X - GetWindowRect().X;
            localPoint.Y = globalMousePoint.X - GetWindowRect().Y;
            return localPoint;
        }

        public static string GetWindowTitle()
        {
            IntPtr windowHandle = GetForegroundWindow();
            const int nChars = 256;
            StringBuilder buffer = new StringBuilder(nChars);
            if (GetWindowText(windowHandle, buffer, nChars) > 0)
            {
                return buffer.ToString();
            }
            return null;
        }


        public static Rectangle GetWindowRect()
        {
            IntPtr windowHandle = GetForegroundWindow();
            GetWindowRect(windowHandle, out Rectangle rectangle);
            rectangle.X = rectangle.Left;
            rectangle.Y = rectangle.Top;
            rectangle.Width = rectangle.Width;
            rectangle.Height = rectangle.Height;
            return rectangle;
        }

        public static uint GetProcessId() 
        {
            IntPtr windowHandle = GetForegroundWindow();
            GetWindowThreadProcessId(windowHandle, out uint processId);
            return processId;
        }
    }
}
