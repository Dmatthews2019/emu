using EventManagement.InputManager.Events.Base;
using EventManagement.InputManager.Events.EventTypes;
using EventManagement.InputManager.Models.Windows;
using EventManagement.InputManager.Repositories.User32Dlls.Mouse;
using System.Drawing;

namespace EventManagement.InputManager.Events.MouseEvents
{
    public class MouseEvent : EventBase
    {
        public MouseEvent(int keyCode, EventType eventType, int delay) : base(keyCode, eventType, delay)
        { }

        public Window Window => new Window();
        public Point MousePosition => MouseDlls.GetCursorPoint();
    }
}
