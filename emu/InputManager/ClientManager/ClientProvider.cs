using emu.InputManager.ClientManager.Interfaces;
using emu.InputManager.Clients.KeyboardClient;
using emu.InputManager.Clients.KeyboardClient.Interfaces;
using emu.InputManager.Clients.MouseClient;
using emu.InputManager.Clients.MouseClient.Interfaces;
using emu.InputManager.Strategies.ErrorStrategies;
using emu.InputManager.Strategies.Interfaces;

namespace emu.InputManager.ClientManager
{
    public class ClientProvider : IClientProvider
    {
        private IErrorHandlingStrategy _errorStrategy;

        public ClientProvider()
        {
            _errorStrategy = new DefaultErrorHandlingStrategy();
            Mouse = new MouseClient(_errorStrategy);
            KeyBoard = new KeyBoardClient(_errorStrategy);
        }

        public ClientProvider(IErrorHandlingStrategy errorHandlingStrategy)
        {
            _errorStrategy = errorHandlingStrategy;
            Mouse = new MouseClient(_errorStrategy);
            KeyBoard = new KeyBoardClient(_errorStrategy);
        }

        public IMouseClient Mouse { get; set; }
        public IKeyBoardClient KeyBoard { get; set; }

    }
}
