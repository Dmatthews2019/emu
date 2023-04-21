namespace EventManagement.InputManager.Events.EventListeners.interfaces
{
    public interface IEventListener<TEvent>
    {
        void RegisterEvent(Action<TEvent> a, int delay);
        bool Paused { get; set; }
        void Stop();
    }
}