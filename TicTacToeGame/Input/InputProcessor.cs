using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Input
{
    public class InputProcessor : IInputProcessor
    {
        public ConsoleKey GetKey()
        {
            var key = Console.ReadKey(false).Key;
            Console.WriteLine();
            return key;
        }
    }
}
