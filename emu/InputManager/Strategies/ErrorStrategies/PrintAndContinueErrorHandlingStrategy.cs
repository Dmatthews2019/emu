using emu.InputManager.Strategies.Interfaces;

namespace emu.InputManager.Strategies.ErrorStrategies
{
    public class PrintAndContinueErrorHandlingStrategy : IErrorHandlingStrategy
    {
        public void OnError(Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        public bool StopListenerOnError { get; } = false;
    }
}
