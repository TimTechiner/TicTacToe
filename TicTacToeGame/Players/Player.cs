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
        protected Element element;
        public Element Element
        {
            get { return element; }
            set { element = value; }
        }
        protected Player() { }
        protected Player(Element element)
        {
            this.element = element;
        }
        public abstract ICommand MakeTurn(Field field);
    }
}
