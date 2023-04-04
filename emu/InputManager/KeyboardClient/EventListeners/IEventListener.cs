using emu.InputManager.KeyEvents;

namespace emu.InputManager.KeyboardClient.EventListeners
{
    public interface IEventListener
    {
        void RegisterEvent(Action<KeyEvent> a, int delay);
        bool Paused { get; set; }

        void Stop();
    }
}