using EventManagement.InputManager.Events.EventListeners.interfaces;
using EventManagement.InputManager.Events.EventListeners.MouseEventListeners.Base;
using EventManagement.InputManager.Events.EventTypes;
using EventManagement.InputManager.Events.MouseEvents;
using EventManagement.InputManager.Strategies.Interfaces;

namespace EventManagement.InputManager.Events.EventListeners.MouseEventListeners
{
    internal class OnMouseEventListener : MouseListenerBase, IEventListener<MouseEvent>
    {
        public OnMouseEventListener(IErrorHandlingStrategy errorStrategy) : base(errorStrategy)
        {
        }
        public void RegisterEvent(Action<MouseEvent> a, int delay)
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
                        for (int i = 0; i < MouseButtonRange; i++)
                        {
                            if (GetAsyncKeyState(i))
                            {
                                currentKey = i;
                                RaiseEvent(a, delay, currentKey, EventType.OnMouse);
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
