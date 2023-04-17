using emu.InputManager.Events.EventTypes;
using emu.InputManager.Events.MouseEvents;
using emu.InputManager.Strategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace emu.InputManager.Events.EventListeners.MouseEventListeners.Base
{
    public abstract class MouseListenerBase
    {
        public const int MouseButtonRange = 6;

        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);


        private IErrorHandlingStrategy _errorStrategy;
        public MouseListenerBase(IErrorHandlingStrategy errorStrategy)
        {
            _errorStrategy = errorStrategy;
        }

        protected readonly CancellationTokenSource _cancellationTokenSource = new();
        public bool Paused { get; set; }
        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
        protected static void RaiseEvent(Action<MouseEvent> a, int delay, int keyCode, EventType eventType)
        {
            GetCursorPos(out Point mousePosition);

            MouseEvent e = new(keyCode, eventType, delay, mousePosition);
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
