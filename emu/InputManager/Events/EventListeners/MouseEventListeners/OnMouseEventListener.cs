using emu.InputManager.Events.Base;
using emu.InputManager.Events.EventListeners.interfaces;
using emu.InputManager.Events.EventListeners.MouseEventListeners.Base;
using emu.InputManager.Events.EventTypes;
using emu.InputManager.Events.MouseEvents;
using emu.InputManager.Strategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emu.InputManager.Events.EventListeners.MouseEventListeners
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
