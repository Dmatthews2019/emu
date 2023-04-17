using emu.InputManager.Events.Base;
using emu.InputManager.Events.EventTypes;
using emu.InputManager.Models.Windows;
using Newtonsoft.Json;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace emu.InputManager.Events.MouseEvents
{
    public class MouseEvent : EventBase
    {
        public MouseEvent(int keyCode, EventType eventType, int delay) : base(keyCode, eventType, delay)
        { }

        private Point _mousePosition;

        public MouseEvent(int keyCode, EventType eventType, int delay, Point mousePosition) : this(keyCode, eventType, delay)
        {
            MousePosition = mousePosition;
            _mousePosition = mousePosition;
        }

        public Window Window { get { return new Window(_mousePosition); } }
        public Point MousePosition { get; }
    }
}
