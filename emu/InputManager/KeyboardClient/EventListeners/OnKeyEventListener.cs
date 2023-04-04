using emu.InputManager.EventTypes;
using emu.InputManager.KeyboardClient.EventListeners.Base;
using emu.InputManager.KeyEvents;

namespace emu.InputManager.KeyboardClient.EventListeners
{
    public class OnKeyEventListener : ListenerBase, IEventListener
    {
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
                                RaiseEvent(a, delay, ref currentKey, EventType.OnKey);
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
