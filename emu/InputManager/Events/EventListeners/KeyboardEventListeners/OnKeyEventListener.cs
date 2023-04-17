using emu.InputManager.Events.EventListeners.interfaces;
using emu.InputManager.Events.EventListeners.KeyboardEventListeners.Base;
using emu.InputManager.Events.EventTypes;
using emu.InputManager.Events.KeyBoardEvents;
using emu.InputManager.Strategies.Interfaces;

namespace emu.InputManager.Events.EventListeners.KeyboardEventListeners
{
    public class OnKeyEventListener : KeyBoardListenerBase, IEventListener<KeyEvent>
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
                            if (GetAsyncKeyState(i) != 0)
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
