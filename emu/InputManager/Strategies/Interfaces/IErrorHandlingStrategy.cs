namespace emu.InputManager.Strategies.Interfaces
{
    public interface IErrorHandlingStrategy
    {
        void OnError(Exception e);
        bool StopListenerOnError { get; }
    }
}