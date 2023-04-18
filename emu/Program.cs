using emu.InputManager.ClientManager;
using emu.InputManager.ClientManager.Interfaces;
using emu.InputManager.KeyCodes.Keyboard;
using MouseCodes = emu.InputManager.KeyCodes.Mouse.KeyCodes;
using System.Diagnostics;

namespace emu
{
    using InputManager.Strategies.Interfaces;

    class Program
    {
        public static void Main()
        {
            IClientProvider eventManager = new ClientProvider();
            eventManager.Mouse.OnMouseUp((e) =>
            {
                Console.WriteLine(e);
            });
            
            
            eventManager.KeyBoard.OnKeyUp((e) =>
            {
                if (e.Code == KeyCodes.A)
                {
                    Console.WriteLine("Pressed A");                    
                    Console.WriteLine(e);                    
                }
                
            });
            
            

            while (true) {
                Thread.Sleep(1000);
            }
        }
    }

}

