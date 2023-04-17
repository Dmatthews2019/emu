using emu.InputManager.Events.EventTypes;
using emu.InputManager.Events.KeyBoardEvents;
using emu.InputManager.Strategies.Interfaces;
using System.Runtime.InteropServices;

namespace emu.InputManager.Events.EventListeners.KeyboardEventListeners.Base
{
    public abstract class KeyBoardListenerBase
    {
        private IErrorHandlingStrategy _errorStrategy;
        public KeyBoardListenerBase(IErrorHandlingStrategy errorStrategy)
        {
            _errorStrategy = errorStrategy;
        }

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

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
