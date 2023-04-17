using emu.InputManager.Strategies.ErrorStrategies;
using emu.InputManager.Strategies.Interfaces;

namespace emu.InputManager.Clients.Base
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
