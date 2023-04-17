using emu.InputManager.Events.EventListeners.interfaces;
using emu.InputManager.Events.KeyBoardEvents;
using System.ComponentModel.DataAnnotations;

namespace emu.InputManager.Clients.KeyboardClient.Interfaces
{
    public interface IKeyBoardClient
    {
        private const int DefaultDelay = 100;
        IEventListener<KeyEvent> OnKey(Action<KeyEvent> a, int delay = DefaultDelay);
        IEventListener<KeyEvent> OnKeyDown(Action<KeyEvent> a, int delay = DefaultDelay);
        IEventListener<KeyEvent> OnKeyUp(Action<KeyEvent> a, int delay = DefaultDelay);
    }
}