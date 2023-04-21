using EventManagement.InputManager.Clients.Base;
using EventManagement.InputManager.Clients.KeyboardClient.Interfaces;
using EventManagement.InputManager.Events.EventListeners.interfaces;
using EventManagement.InputManager.Events.EventListeners.KeyboardEventListeners;
using EventManagement.InputManager.Events.KeyBoardEvents;
using EventManagement.InputManager.Strategies.Interfaces;

namespace EventManagement.InputManager.Clients.KeyboardClient
{
    public class KeyBoardClient : PeripheralClientBase, IKeyBoardClient
    {
        public KeyBoardClient() : base()
        {
        }

        public KeyBoardClient(IErrorHandlingStrategy errorHandlingStrategy) : base(errorHandlingStrategy)
        {
        }

        public IEventListener<KeyEvent> OnKeyUp(Action<KeyEvent> a, int delay)
        {
            IEventListener<KeyEvent> keyUpRegister = new OnKeyUpEventListener(_errorStrategy);
            keyUpRegister.RegisterEvent(a, delay);
            return keyUpRegister;
        }

        public IEventListener<KeyEvent> OnKeyDown(Action<KeyEvent> a, int delay)
        {
            IEventListener<KeyEvent> keyDownRegister = new OnKeyDownEventListener(_errorStrategy);
            keyDownRegister.RegisterEvent(a, delay);
            return keyDownRegister;
        }

        public IEventListener<KeyEvent> OnKey(Action<KeyEvent> a, int delay)
        {
            IEventListener<KeyEvent> keyRegister = new OnKeyEventListener(_errorStrategy);
            keyRegister.RegisterEvent(a, delay);
            return keyRegister;
        }

    }

}

