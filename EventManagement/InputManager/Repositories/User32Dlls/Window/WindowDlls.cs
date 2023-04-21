using EventManagement.InputManager.Models.HardwareInfo;
using EventManagement.InputManager.Models.Shapes;
using EventManagement.InputManager.Repositories.User32Dlls.Base;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace EventManagement.InputManager.Repositories.User32Dlls.Window
{
    internal class WindowDlls : User32DllBase
    {
        public static IntPtr GetActiveWindow()
        {
            return GetForegroundWindow();
        }

        public static uint GetWindowThreadId(IntPtr hWnd)
        {
            GetWindowThreadProcessId(hWnd, out uint lpdwProcessId);
            return lpdwProcessId;
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
            return string.Empty;
        }

        public static Rectangle GetWindowRectangle(IntPtr hWnd)
        {
            if (GetWindowRect(hWnd, out Rect rect))
            {
                IntPtr hMonitor = MonitorFromWindow(hWnd, 2 /* MONITOR_DEFAULTTONEAREST */);
                MONITORINFO monitorInfo = new MONITORINFO();
                monitorInfo.cbSize = Marshal.SizeOf(monitorInfo);
                if (GetMonitorInfo(hMonitor, ref monitorInfo))
                {
                    int offsetX = monitorInfo.rcMonitor.left;
                    int offsetY = monitorInfo.rcMonitor.top;
                    return new Rectangle(rect.left - offsetX, rect.top - offsetY, rect.right - rect.left, rect.bottom - rect.top);
                }
            }
            throw new Exception("Failed to get window rectangle");
        }

        public static Rectangle GetWindowRectangleAll(IntPtr hWnd)
        {
            if (GetWindowRect(hWnd, out Rect rect))
            {
                return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
            }
            return new Rectangle(0, 0, 0, 0);
        }

        public static Rectangle GetWindowRect()
        {
            IntPtr windowHandle = GetForegroundWindow();
            var rectangle = GetWindowRectangle(windowHandle);
            return rectangle;
        }
        public static Rectangle GetWindowRectAll()
        {
            IntPtr windowHandle = GetForegroundWindow();
            var rectangle = GetWindowRectangleAll(windowHandle);
            return rectangle;
        }

        public static uint GetWindowProcessId()
        {
            IntPtr windowHandle = GetForegroundWindow();
            GetWindowThreadProcessId(windowHandle, out uint processId);
            return processId;
        }
    }
}
