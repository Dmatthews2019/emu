namespace EventManagement.InputManager.Strategies.Interfaces
{
    public interface IErrorHandlingStrategy
    {
        void OnError(Exception e);
        bool StopListenerOnError { get; }
    }
}