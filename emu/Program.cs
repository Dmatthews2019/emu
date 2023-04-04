using emu.InputManager.KeyboardClient;
using emu.InputManager.KeyboardClient.EventListeners;
using emu.InputManager.KeyCodes;

namespace emu
{
    class Program
    {

        public static void Main()
        {
            IKeyBoardEventManager keyboardEventManager = new KeyBoardEventManager();
            keyboardEventManager.OnKey(
                    (e) =>
                    {
                        Console.WriteLine(e.ToString());
                    }
                );

            while (true)
            {
                Thread.Sleep(100);
                
            }
        }


    }

}

