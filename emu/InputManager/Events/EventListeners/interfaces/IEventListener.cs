using emu.InputManager.Events.Base;
using emu.InputManager.Events.KeyBoardEvents;

namespace emu.InputManager.Events.EventListeners.interfaces
{
    public interface IEventListener<TEvent>
    {
        void RegisterEvent(Action<TEvent> a, int delay);
        bool Paused { get; set; }
        void Stop();
    }
}