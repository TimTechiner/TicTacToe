﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Command
{
    public class EmptyCommand : ICommand
    {
        public void Execute() { }
    }
}
