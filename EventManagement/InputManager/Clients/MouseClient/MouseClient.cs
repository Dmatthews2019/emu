using EventManagement.InputManager.Clients.Base;
using EventManagement.InputManager.Clients.MouseClient.Interfaces;
using EventManagement.InputManager.Events.EventListeners.interfaces;
using EventManagement.InputManager.Events.EventListeners.MouseEventListeners;
using EventManagement.InputManager.Events.MouseEvents;
using EventManagement.InputManager.Models.Windows;
using EventManagement.InputManager.Strategies.Interfaces;

namespace EventManagement.InputManager.Clients.MouseClient
{
    public class MouseClient : PeripheralClientBase, IMouseClient
    {
        public MouseClient() : base()
        {
        }

        public MouseClient(IErrorHandlingStrategy errorHandlingStrategy) : base(errorHandlingStrategy)
        {
        }

        public static Window Window { get; set; } = new Window();

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
