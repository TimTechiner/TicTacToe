using TicTacToeGame.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.CustomEventArgs
{
    public class CommandSentEventArgs : EventArgs
    {
        public ICommand Command { get; set; }
        public CommandSentEventArgs(ICommand command)
        {
            Command = command;
        }
    }
}
