using EventManagement.InputManager.ClientManager.Interfaces;
using EventManagement.InputManager.Clients.KeyboardClient;
using EventManagement.InputManager.Clients.KeyboardClient.Interfaces;
using EventManagement.InputManager.Clients.MouseClient;
using EventManagement.InputManager.Clients.MouseClient.Interfaces;
using EventManagement.InputManager.Strategies.ErrorStrategies;
using EventManagement.InputManager.Strategies.Interfaces;

namespace EventManagement.InputManager.ClientManager
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
