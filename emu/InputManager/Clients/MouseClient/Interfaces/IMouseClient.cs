using emu.InputManager.Events.Base;
using emu.InputManager.Events.EventListeners.interfaces;
using emu.InputManager.Events.MouseEvents;

namespace emu.InputManager.Clients.MouseClient.Interfaces
{
    public interface IMouseClient
    {
        IEventListener<MouseEvent> OnMouse(Action<MouseEvent> a, int delay = 100);
        IEventListener<MouseEvent> OnMouseDown(Action<MouseEvent> a, int delay = 100);
        IEventListener<MouseEvent> OnMouseUp(Action<MouseEvent> a, int delay = 100);
    }
}