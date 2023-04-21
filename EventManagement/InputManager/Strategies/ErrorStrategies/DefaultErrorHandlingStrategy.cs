using EventManagement.InputManager.Strategies.Interfaces;

namespace EventManagement.InputManager.Strategies.ErrorStrategies
{
    public class DefaultErrorHandlingStrategy : IErrorHandlingStrategy
    {
        public void OnError(Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        public bool StopListenerOnError { get; } = true;
    }
}
