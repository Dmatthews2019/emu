using emu.InputManager.Events.Base;
using emu.InputManager.Events.EventTypes;

namespace emu.InputManager.Events.KeyBoardEvents
{
    public class KeyEvent : EventBase
    {
        public KeyEvent(int keyCode, EventType eventType, int delay) : base(keyCode, eventType, delay)
        { }
    }
}
