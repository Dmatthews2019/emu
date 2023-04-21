using EventManagement.InputManager.Events.EventListeners.interfaces;
using EventManagement.InputManager.Events.MouseEvents;

namespace EventManagement.InputManager.Clients.MouseClient.Interfaces
{
    public interface IMouseClient
    {
        IEventListener<MouseEvent> OnMouse(Action<MouseEvent> a, int delay = 100);
        IEventListener<MouseEvent> OnMouseDown(Action<MouseEvent> a, int delay = 100);
        IEventListener<MouseEvent> OnMouseUp(Action<MouseEvent> a, int delay = 100);
    }
}