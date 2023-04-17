using emu.InputManager.Events.EventListeners.interfaces;
using emu.InputManager.Events.EventListeners.MouseEventListeners.Base;
using emu.InputManager.Events.EventTypes;
using emu.InputManager.Events.MouseEvents;
using emu.InputManager.Strategies.Interfaces;

namespace emu.InputManager.Events.EventListeners.MouseEventListeners
{
    internal class OnMouseDownEventListener : MouseListenerBase, IEventListener<MouseEvent>
    {
        public OnMouseDownEventListener(IErrorHandlingStrategy errorStrategy) : base(errorStrategy)
        {
        }

        public void RegisterEvent(Action<MouseEvent> a, int delay)
        {

            Task.Run(() =>
            {
                HashSet<int> pressedKeys = new HashSet<int>();
                ManualResetEventSlim signal = new(true);
                while (!_cancellationTokenSource.IsCancellationRequested && !Paused)
                {
                    try
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (GetAsyncKeyState(i) && !pressedKeys.Contains(i))
                            {
                                pressedKeys.Add(i);
                                RaiseEvent(a, delay, i, EventType.OnKeyDown);
                            }
                            if (pressedKeys.Contains(i) && !GetAsyncKeyState(i))
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
