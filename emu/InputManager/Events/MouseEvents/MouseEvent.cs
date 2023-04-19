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

        public Window Window => new Window();
        public Point MousePosition => GetCursorPoint();
    }
}
