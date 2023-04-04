using emu.InputManager.EventTypes;
using emu.InputManager.KeyboardClient.EventListeners.Base;
using emu.InputManager.KeyEvents;

namespace emu.InputManager.KeyboardClient.EventListeners
{
    public class OnKeyDownEventListener : ListenerBase, IEventListener
    {

        public void RegisterEvent(Action<KeyEvent> a, int delay)
        {
            bool locked = false;
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
                            if (GetAsyncKeyState(i) != 0 && !locked)
                            {
                                locked = true;
                                currentKey = i;
                                RaiseEvent(a, delay, ref currentKey, EventType.OnKey);
                            }
                            if (i == currentKey && GetAsyncKeyState(i) == 0)
                            {
                                locked = false;
                                currentKey = -1;
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
