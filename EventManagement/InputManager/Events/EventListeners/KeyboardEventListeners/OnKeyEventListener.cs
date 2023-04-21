using EventManagement.InputManager.Events.EventListeners.interfaces;
using EventManagement.InputManager.Events.EventListeners.KeyboardEventListeners.Base;
using EventManagement.InputManager.Events.EventTypes;
using EventManagement.InputManager.Events.KeyBoardEvents;
using EventManagement.InputManager.Repositories.User32Dlls.Keyboard;
using EventManagement.InputManager.Strategies.Interfaces;

namespace EventManagement.InputManager.Events.EventListeners.KeyboardEventListeners
{
    internal class OnKeyEventListener : KeyBoardListenerBase, IEventListener<KeyEvent>
    {
        public OnKeyEventListener(IErrorHandlingStrategy errorStrategy) : base(errorStrategy)
        {
        }
        public void RegisterEvent(Action<KeyEvent> a, int delay)
        {
            Task.Run(() =>
            {
                ManualResetEventSlim signal = new(true);
                int currentKey = -1;
                while (!_cancellationTokenSource.IsCancellationRequested && !Paused)
                {
                    try
                    {
                        for (int i = 0; i < 255; i++)
                        {
                            if (KeyboardDlls.GetAsyncKeyState(i) != 0)
                            {
                                currentKey = i;
                                RaiseEvent(a, delay, currentKey, EventType.OnKey);
                            }
                        }
                        signal.Wait(100);
                        signal.Reset();
                    }
                    catch (Exception e)
                    {
                        HandleException(e);
                    }
                }

            });
        }
    }
}
