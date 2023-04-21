namespace EventManagement.InputManager.Events.KeyBoardEvents
{
    using EventManagement.InputManager.Events.Base;
    using EventManagement.InputManager.Events.EventTypes;
    using Models.Windows;

    public class KeyEvent : EventBase
    {
        public KeyEvent(int keyCode, EventType eventType, int delay) : base(keyCode, eventType, delay)
        { }

        public Window Window { get { return new Window(); } }

    }
}
