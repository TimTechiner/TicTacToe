using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.CustomExceptions
{
    public class FieldInvalidException: Exception
    {
        public FieldInvalidException() { }
        public FieldInvalidException(string message) : base(message) { }
    }
}
