using emu.InputManager.Events.EventTypes;
using Newtonsoft.Json;

namespace emu.InputManager.Events.Base
{
    public class EventBase
    {
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

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}