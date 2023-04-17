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

        public Window(Point globalMousePoint)
        {
            _globalMousePoint = globalMousePoint;
        }

        public string Title => GetWindowTitle();
        public Rectangle Rectangle => GetWindowRect();
        public Point LocalMousePosition => ComputeLocalMousePosition(_globalMousePoint);
        public Size Size => this.Rectangle.Size;
        public Point Location => this.Rectangle.Location;
        public uint ProcessId => GetProcessId();


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
