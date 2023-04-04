using emu.InputManager.EventTypes;
using emu.InputManager.KeyboardClient.EventListeners.Base;
using emu.InputManager.KeyEvents;

namespace emu.InputManager.KeyboardClient.EventListeners
{
    internal class OnKeyUpEventListener : ListenerBase, IEventListener
    {
        public void RegisterEvent(Action<KeyEvent> a, int delay)
        {
            Task.Run(
            () =>
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
                            }
                            if (i == currentKey && GetAsyncKeyState(i) == 0)
                            {
                                RaiseEvent(a, delay, ref currentKey, EventType.OnKey);
                            }
                        }
                        signal.Wait(delay);
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
