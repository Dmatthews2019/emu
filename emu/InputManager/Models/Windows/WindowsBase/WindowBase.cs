using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace emu.InputManager.Models.Windows.WindowsBase
{
    using HardwareInfo;
    using Shapes;

    public abstract class WindowBase
    {
        public static Rectangle GetWindowRectangle(IntPtr hWnd)
        {
            if (ExternalWindowClient.GetWindowRect(hWnd, out Rect rect))
            {
                IntPtr hMonitor = ExternalWindowClient.MonitorFromWindow(hWnd, 2 /* MONITOR_DEFAULTTONEAREST */);
                MONITORINFO monitorInfo = new MONITORINFO();
                monitorInfo.cbSize = Marshal.SizeOf(monitorInfo);
                if (ExternalWindowClient.GetMonitorInfo(hMonitor, ref monitorInfo))
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
            if (ExternalWindowClient.GetWindowRect(hWnd, out Rect rect))
            {
                return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
            }
            throw new Exception("Failed to get window rectangle");
        }

        public static Point ComputeLocalMousePosition(Point globalMousePoint)
        {
            Point localPoint = new Point();
            localPoint.X = globalMousePoint.X - GetWindowRect().X;
            localPoint.Y = globalMousePoint.Y - GetWindowRect().Y;
            return localPoint;
        }

        public static string GetWindowTitle()
        {
            IntPtr windowHandle = ExternalWindowClient.GetForegroundWindow();
            const int nChars = 256;
            StringBuilder buffer = new StringBuilder(nChars);
            if (ExternalWindowClient.GetWindowText(windowHandle, buffer, nChars) > 0)
            {
                return buffer.ToString();
            }
            return null;
        }


        public static Rectangle GetWindowRect()
        {
            IntPtr windowHandle = ExternalWindowClient.GetForegroundWindow();
            var rectangle = GetWindowRectangle(windowHandle);
            return rectangle;
        }
        public static Rectangle GetWindowRectAll()
        {
            IntPtr windowHandle = ExternalWindowClient.GetForegroundWindow();
            var rectangle = GetWindowRectangleAll(windowHandle);
            return rectangle;
        }

        public static uint GetProcessId() 
        {
            IntPtr windowHandle = ExternalWindowClient.GetForegroundWindow();
            ExternalWindowClient.GetWindowThreadProcessId(windowHandle, out uint processId);
            return processId;
        }
        
        public static Point GetCursorPoint()
        {
            ExternalWindowClient.GetCursorPos(out Point lpPoint);
            return lpPoint;
        }
    }
}
