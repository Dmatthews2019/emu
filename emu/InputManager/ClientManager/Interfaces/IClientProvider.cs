using emu.InputManager.Clients.KeyboardClient.Interfaces;
using emu.InputManager.Clients.MouseClient.Interfaces;

namespace emu.InputManager.ClientManager.Interfaces
{
    public interface IClientProvider
    {
        IKeyBoardClient KeyBoard { get; set; }
        IMouseClient Mouse { get; set; }
    }
}