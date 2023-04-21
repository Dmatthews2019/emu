using EventManagement.InputManager.Repositories.User32Dlls.Mouse;
using System.Drawing;

namespace EventManagement.InputManager.Models.Mice
{
    public class Mouse
    {
        public Point Point => MouseDlls.GetCursorPoint();

    }
}
