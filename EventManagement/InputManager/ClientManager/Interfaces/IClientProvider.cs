using EventManagement.InputManager.Clients.KeyboardClient.Interfaces;
using EventManagement.InputManager.Clients.MouseClient.Interfaces;

namespace EventManagement.InputManager.ClientManager.Interfaces
{
    public interface IClientProvider
    {
        IKeyBoardClient KeyBoard { get; set; }
        IMouseClient Mouse { get; set; }
    }
}