using EventManagement.InputManager.Events.EventTypes;
using EventManagement.InputManager.Events.KeyBoardEvents;
using EventManagement.InputManager.Strategies.Interfaces;

namespace EventManagement.InputManager.Events.EventListeners.KeyboardEventListeners.Base
{
    internal abstract class KeyBoardListenerBase
    {
        private IErrorHandlingStrategy _errorStrategy;
        public KeyBoardListenerBase(IErrorHandlingStrategy errorStrategy)
        {
            _errorStrategy = errorStrategy;
        }

        protected readonly CancellationTokenSource _cancellationTokenSource = new();
        public bool Paused { get; set; }
        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
        protected static void RaiseEvent(Action<KeyEvent> a, int delay, int keyCode, EventType eventType)
        {
            KeyEvent e = new(keyCode, eventType, delay);
            Thread.Sleep(delay);
            a.Invoke(e);
        }
        protected void HandleException(Exception e)
        {
            if (_errorStrategy.StopListenerOnError)
            {
                Paused = true;
                _cancellationTokenSource.Cancel();
            }
            _errorStrategy.OnError(e);
        }
    }
}
