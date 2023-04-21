using EventManagement.InputManager.Strategies.ErrorStrategies;
using EventManagement.InputManager.Strategies.Interfaces;

namespace EventManagement.InputManager.Clients.Base
{
    public abstract class PeripheralClientBase
    {
        protected IErrorHandlingStrategy _errorStrategy;

        public PeripheralClientBase()
        {
            _errorStrategy = new DefaultErrorHandlingStrategy();
        }

        public PeripheralClientBase(IErrorHandlingStrategy errorHandlingStrategy)
        {
            _errorStrategy = errorHandlingStrategy;
        }
    }
}
