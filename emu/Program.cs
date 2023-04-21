using EventManagement.InputManager.ClientManager;
using EventManagement.InputManager.ClientManager.Interfaces;
using EventManagement.InputManager.Clients.MouseClient;
using EventManagement.InputManager.KeyCodes.Keyboard;

namespace emu
{
    class Program
    {
        public static void Main()
        {
            IClientProvider eventManager = new ClientProvider();
            eventManager.Mouse.OnMouseUp(e =>
            {
                Console.WriteLine(e);
            });

            eventManager.KeyBoard.OnKeyUp(e =>
            {
                if (e.Code == KeyCodes.A)
                {
                    Console.WriteLine("Pressed A");
                    Console.WriteLine(e);
                }
            });

            while (true) {
                Thread.Sleep(100);
                Console.WriteLine(MouseClient.Window.LocalMousePosition);
            }
        }
    }
}

