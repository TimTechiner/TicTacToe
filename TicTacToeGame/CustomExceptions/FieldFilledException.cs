using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.CustomExceptions
{
    public class FieldFilledException : Exception
    {
        public FieldFilledException() { }
        public FieldFilledException(string message) : base(message) { }
    }
}
