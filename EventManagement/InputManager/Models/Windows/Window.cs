using EventManagement.InputManager.Repositories.User32Dlls.Mouse;
using EventManagement.InputManager.Repositories.User32Dlls.Window;
using Newtonsoft.Json;
using System.Drawing;

namespace EventManagement.InputManager.Models.Windows
{
    public class Window
    {
        public string Title => WindowDlls.GetWindowTitle();
        public Rectangle RelativeMonitorRectangle => WindowDlls.GetWindowRect();
        public Rectangle Rectangle => WindowDlls.GetWindowRectAll();
        public Point LocalMousePosition => MouseDlls.ComputeLocalMousePosition();
        public Size Size => new Size(Rectangle.Width, Rectangle.Height);
        public Point Location => Rectangle.Location;
        public uint ProcessId => WindowDlls.GetWindowProcessId();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
