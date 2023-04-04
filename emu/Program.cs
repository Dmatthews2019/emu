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
            for (int i = 0; i < 10000; i++)
            {
                keyboardEventManager.OnKey((e) =>
                    {
                        Console.WriteLine(e);
                    }
                );
            }

            while (true)
            {
                Thread.Sleep(100);
            }
        }


    }

}

