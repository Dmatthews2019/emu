using emu.InputManager.Events.EventTypes;
using Newtonsoft.Json;

namespace emu.InputManager.Events.Base
{
    using System.Drawing;
    using System.Runtime.InteropServices;

    public abstract class EventBase
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);
        public EventBase(int keyCode, EventType eventType, int delay)
        {
            Code = keyCode;
            KeyName = ((ConsoleKey)keyCode).ToString();
            EventTime = DateTime.Now;
            TriggeredBy = Environment.UserName;
            EventId = Guid.NewGuid();
            EventType = eventType;
            Delay = delay;
        }
        public int Code { get; init; }
        public DateTime EventTime { get; init; }
        public string TriggeredBy { get; init; }
        public int Delay { get; init; }
        public string KeyName { get; init; }
        public Guid EventId { get; init; }
        public int ThreadId { get; } = Thread.CurrentThread.ManagedThreadId;
        public EventType EventType { get; init; }

        public static Point GetCursorPoint()
        {
            GetCursorPos(out Point lpPoint);
            return lpPoint;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}