using emu.InputManager.ClientManager;
using emu.InputManager.ClientManager.Interfaces;
using emu.InputManager.KeyCodes.Keyboard;
using System.Diagnostics;

namespace emu
{
    class Program
    {
        
        public static void Main()
        {
            IClientProvider eventManager = new ClientProvider();
            eventManager.Mouse.OnMouseUp((e) => 
            {
                if (e.Code == 2 && e.Window.Title.ToLower().Contains("note"))
                {
                    Process process = Process.GetProcessById((int)e.Window.ProcessId);
                    if (process != null )
                    {
                        process.Kill(); // End the process
                    }
                }
            });

            while (true) {
                Thread.Sleep(1000);
            }
        }
    }

}

