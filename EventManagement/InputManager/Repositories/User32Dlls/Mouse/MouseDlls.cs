using EventManagement.InputManager.Repositories.User32Dlls.Base;
using EventManagement.InputManager.Repositories.User32Dlls.Window;
using System.Drawing;

namespace EventManagement.InputManager.Repositories.User32Dlls.Mouse
{
    internal class MouseDlls : User32DllBase
    {
        public static Point GetCursorPoint()
        {
            GetCursorPos(out Point lpPoint);
            return lpPoint;
        }

        public static Point ComputeLocalMousePosition()
        {
            GetCursorPos(out Point lpPoint);
            Point localPoint = new Point();
            localPoint.X = lpPoint.X - WindowDlls.GetWindowRectAll().X;
            localPoint.Y = lpPoint.Y - WindowDlls.GetWindowRectAll().Y;
            return localPoint;
        }

    }
}
