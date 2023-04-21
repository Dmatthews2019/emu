using EventManagement.InputManager.Strategies.Interfaces;
using System.Diagnostics;

namespace EventManagement.InputManager.Strategies.ErrorStrategies
{
    public class TerminateErrorHandlingStrategy : IErrorHandlingStrategy
    {
        public void OnError(Exception e)
        {
            Process.GetCurrentProcess().CloseMainWindow();
        }

        public bool StopListenerOnError { get; } = false;
    }
}
