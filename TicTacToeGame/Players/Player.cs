using TicTacToeGame.Command;
using TicTacToeGame.Enums;

namespace TicTacToeGame.Players
{
    public abstract class Player
    {
        public Element Element { get; set; }
        protected Player() { }
        public abstract ICommand MakeTurn(Field field);
    }
}
