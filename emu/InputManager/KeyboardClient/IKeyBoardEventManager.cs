using emu.InputManager.KeyboardClient.EventListeners;
using emu.InputManager.KeyEvents;
using System.ComponentModel.DataAnnotations;

namespace emu.InputManager.KeyboardClient
{
    public interface IKeyBoardEventManager
    {
        private const int DefaultDelay = 100;
        IEventListener OnKey(Action<KeyEvent> a, int delay = DefaultDelay);
        IEventListener OnKeyDown(Action<KeyEvent> a, int delay = DefaultDelay);
        IEventListener OnKeyUp(Action<KeyEvent> a, int delay = DefaultDelay);
    }
}