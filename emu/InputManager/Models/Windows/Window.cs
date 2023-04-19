using emu.InputManager.Models.Windows.WindowsBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace emu.InputManager.Models.Windows
{
    public class Window : WindowBase
    {

        
        private Point _globalMousePoint;

        public Window()
        {
            _globalMousePoint = GetCursorPoint();
        }

        public string Title => GetWindowTitle();
        public Rectangle RelativeMonitorRectangle => GetWindowRect();
        public Rectangle Rectangle => GetWindowRectAll();
        public Point LocalMousePosition => ComputeLocalMousePosition(_globalMousePoint);
        public Size Size => new Size(this.Rectangle.Width, this.Rectangle.Height);
        public Point Location => this.Rectangle.Location;
        public uint ProcessId => GetProcessId();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
