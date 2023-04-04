using emu.InputManager.EventTypes;

namespace emu.InputManager.KeyEvents
{
    public class KeyEvent
    {
        public KeyEvent(int keyCode, EventType eventType , int delay)
        {
            KeyCode = keyCode;
            KeyName = ((ConsoleKey)keyCode).ToString();
            EventTime = DateTime.Now;
            TriggeredBy = Environment.UserName;
            EventId = Guid.NewGuid();
            EventType = eventType;
            Delay = delay;
        }

        public int KeyCode { get; }
        public DateTime EventTime { get; }
        public string TriggeredBy { get; }
        public int Delay { get; }
        public string KeyName { get; }
        public Guid EventId { get; }
        public int ThreadId { get; } = Thread.CurrentThread.ManagedThreadId;
        public EventType EventType { get; }

        public override string ToString() 
        {
            return 
                $"=========================\n" +
                $"KeyCode: {KeyCode}\n" +
                $"EventTime: {EventTime}\n" +
                $"TriggeredBy: {TriggeredBy}\n" +
                $"Delay: {Delay}\n" +
                $"KeyName: {KeyName}\n" +
                $"EventId: {EventId}\n" +
                $"ThreadId: {ThreadId}\n" +
                $"EventType: {EventType}\n" +
                $"=========================";
        }

    }
}
