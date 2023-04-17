using emu.InputManager.Events.EventListeners.interfaces;
using emu.InputManager.Events.EventListeners.KeyboardEventListeners.Base;
using emu.InputManager.Events.EventTypes;
using emu.InputManager.Events.KeyBoardEvents;
using emu.InputManager.Events.MouseEvents;
using emu.InputManager.Strategies.Interfaces;

namespace emu.InputManager.Events.EventListeners.KeyboardEventListeners
{
    public class OnKeyDownEventListener : KeyBoardListenerBase, IEventListener<KeyEvent>
    {
        public OnKeyDownEventListener(IErrorHandlingStrategy errorStrategy) : base(errorStrategy)
        {
        }

        public void RegisterEvent(Action<KeyEvent> a, int delay)
        {

            Task.Run(() =>
            {
                HashSet<int> pressedKeys = new HashSet<int>();
                ManualResetEventSlim signal = new(true);
                while (!_cancellationTokenSource.IsCancellationRequested && !Paused)
                {
                    try
                    {
                        for (int i = 0; i < 255; i++)
                        {
                            if (GetAsyncKeyState(i) != 0 && !pressedKeys.Contains(i))
                            {
                                pressedKeys.Add(i);
                                RaiseEvent(a, delay, i, EventType.OnKeyDown);
                            }
                            if (pressedKeys.Contains(i) && GetAsyncKeyState(i) == 0)
                            {
                                pressedKeys.Remove(i);
                            }
                        }
                        signal.Wait(100);
                        signal.Reset();
                    }
                    catch (Exception e)
                    {
                        pressedKeys.Clear();
                        HandleException(e);
                    }
                }
            });
        }

    }
}
