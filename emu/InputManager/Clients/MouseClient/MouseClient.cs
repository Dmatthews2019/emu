using emu.InputManager.Clients.Base;
using emu.InputManager.Clients.MouseClient.Interfaces;
using emu.InputManager.Events.Base;
using emu.InputManager.Events.EventListeners.interfaces;
using emu.InputManager.Events.EventListeners.MouseEventListeners;
using emu.InputManager.Events.MouseEvents;
using emu.InputManager.Strategies.Interfaces;

namespace emu.InputManager.Clients.MouseClient
{
    public class MouseClient : PeripheralClientBase , IMouseClient
    {
        public MouseClient() : base()
        {
        }

        public MouseClient(IErrorHandlingStrategy errorHandlingStrategy) : base(errorHandlingStrategy)
        {
        }

        public IEventListener<MouseEvent> OnMouse(Action<MouseEvent> a, int delay = 100)
        {
            IEventListener<MouseEvent> mouseRegister = new OnMouseEventListener(_errorStrategy);
            mouseRegister.RegisterEvent(a, delay);
            return mouseRegister;
        }

        public IEventListener<MouseEvent> OnMouseDown(Action<MouseEvent> a, int delay = 100)
        {
            IEventListener<MouseEvent> mouseDownRegister = new OnMouseDownEventListener(_errorStrategy);
            mouseDownRegister.RegisterEvent(a, delay);
            return mouseDownRegister;
        }

        public IEventListener<MouseEvent> OnMouseUp(Action<MouseEvent> a, int delay = 100)
        {
            IEventListener<MouseEvent> mouseUpRegister = new OnMouseUpEventListener(_errorStrategy);
            mouseUpRegister.RegisterEvent(a, delay);
            return mouseUpRegister;
        }

    }
}
