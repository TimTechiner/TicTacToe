using TicTacToeGame.Command;
using TicTacToeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Players
{
    public abstract class Player
    {
        public Element Element { get; set; }
        protected Player() { }
        public abstract ICommand MakeTurn(Field field);
    }
}
