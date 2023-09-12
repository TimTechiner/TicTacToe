using TicTacToeGame.AIStrategies;
using TicTacToeGame.Command;


namespace TicTacToeGame.Players
{
    public class AIPlayer : Player
    {
        public IPlayStrategy Strategy { get; set; } = new AIRandomStrategy();
        public AIPlayer() : base() { }
        public override ICommand MakeTurn(Field field)
        {
            var targetCell = Strategy.GetNextTargetCell(field, Element);

            return new SetFieldElementCommand(field, Element, targetCell);
        }
    }
}
