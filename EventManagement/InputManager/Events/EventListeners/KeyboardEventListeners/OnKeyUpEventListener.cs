using EventManagement.InputManager.Events.EventListeners.interfaces;
using EventManagement.InputManager.Events.EventListeners.KeyboardEventListeners.Base;
using EventManagement.InputManager.Events.EventTypes;
using EventManagement.InputManager.Events.KeyBoardEvents;
using EventManagement.InputManager.Repositories.User32Dlls.Keyboard;
using EventManagement.InputManager.Strategies.Interfaces;

namespace EventManagement.InputManager.Events.EventListeners.KeyboardEventListeners
{
    internal class OnKeyUpEventListener : KeyBoardListenerBase, IEventListener<KeyEvent>
    {
        public OnKeyUpEventListener(IErrorHandlingStrategy errorStrategy) : base(errorStrategy)
        {
        }
        public void RegisterEvent(Action<KeyEvent> a, int delay)
        {
            Task.Run(
            () =>
            {
                HashSet<int> pressedKeys = new HashSet<int>();
                ManualResetEventSlim signal = new(true);
                while (!_cancellationTokenSource.IsCancellationRequested && !Paused)
                {
                    try
                    {
                        for (int i = 0; i < 255; i++)
                        {
                            if (KeyboardDlls.GetAsyncKeyState(i) != 0 && !pressedKeys.Contains(i))
                            {
                                pressedKeys.Add(i);
                            }
                            if (pressedKeys.Contains(i) && KeyboardDlls.GetAsyncKeyState(i) == 0)
                            {
                                pressedKeys.Remove(i);
                                RaiseEvent(a, delay, i, EventType.OnKeyUp);
                            }
                        }
                        signal.Wait(delay);
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
