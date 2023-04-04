using emu.InputManager.EventTypes;
using emu.InputManager.KeyEvents;
using System.Runtime.InteropServices;

namespace emu.InputManager.KeyboardClient.EventListeners.Base
{
    public abstract class ListenerBase
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        protected readonly CancellationTokenSource _cancellationTokenSource = new();
        public bool Paused { get; set; }
        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
        protected static void RaiseEvent(Action<KeyEvent> a, int delay, ref int keyCode, EventType eventType )
        {
            
            KeyEvent e = new(keyCode, eventType, delay);
            Thread.Sleep(delay);
            a.Invoke(e);
            keyCode = -1;
        }
        protected void HandleException(Exception e)
        {
            Console.WriteLine(e.ToString());
            Paused = true;
            _cancellationTokenSource.Cancel();
        }
    }
}
