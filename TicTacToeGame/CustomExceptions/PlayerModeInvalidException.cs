using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.CustomExceptions
{
    public class PlayerModeInvalidException: Exception
    {
        public PlayerModeInvalidException() { }
        public PlayerModeInvalidException(string message) : base(message) { }
    }
}
