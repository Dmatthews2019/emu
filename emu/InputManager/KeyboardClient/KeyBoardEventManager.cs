using emu.InputManager.KeyboardClient.EventListeners;
using emu.InputManager.KeyEvents;
using static emu.InputManager.Structs.Input;

namespace emu.InputManager.KeyboardClient
{
    public class KeyBoardEventManager : IKeyBoardEventManager
    {
        const int INPUT_KEYBOARD = 1;
        private INPUT input;

        public KeyBoardEventManager()
        {
            input = new INPUT();
            input.type = INPUT_KEYBOARD;
            input.u.ki.wScan = 0;
            input.u.ki.time = 0;
            input.u.ki.dwExtraInfo = IntPtr.Zero;
        }

        public IEventListener OnKeyUp(Action<KeyEvent> a, int delay)
        {
            IEventListener keyUpRegister = new OnKeyUpEventListener();
            keyUpRegister.RegisterEvent(a, delay);
            return keyUpRegister;
        }

        public IEventListener OnKeyDown(Action<KeyEvent> a, int delay)
        {
            IEventListener keyDownRegister = new OnKeyDownEventListener();
            keyDownRegister.RegisterEvent(a, delay);
            return keyDownRegister;
        }

        public IEventListener OnKey(Action<KeyEvent> a, int delay)
        {
            IEventListener keyRegister = new OnKeyEventListener();
            keyRegister.RegisterEvent(a, delay);
            return keyRegister;
        }

    }

}

