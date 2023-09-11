using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.AIStrategies;
using TicTacToeGame.Command;
using TicTacToeGame.Enums;

namespace TicTacToeGame.Players
{
    public class AIPlayer : Player
    {
        public IPlayStrategy Strategy { get; set; }
        public AIPlayer() : base() { }
        public AIPlayer(Element element) : base(element) { }
        public override ICommand MakeTurn(Field field)
        {
            var targetCell = Strategy.GetNextTargetCell(field, element);

            return new SetFieldElementCommand(field, Element, targetCell);
        }
    }
}
