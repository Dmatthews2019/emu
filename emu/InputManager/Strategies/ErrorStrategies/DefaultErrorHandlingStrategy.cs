using emu.InputManager.Strategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emu.InputManager.Strategies.ErrorStrategies
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
