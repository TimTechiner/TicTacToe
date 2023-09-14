using TicTacToeGame.AIStrategies;
using TicTacToeGame.Command;


namespace TicTacToeGame.Players
{
    public class AIPlayer : Player
    {
        private IPlayStrategy strategy = new AIRandomStrategy();
        public IPlayStrategy Strategy
        {
            get => strategy;
            set
            {
                if (value  == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                strategy = value;
            }
        }
        public AIPlayer() : base() { }
        public override ICommand MakeTurn(Field field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            var targetCell = Strategy.GetNextTargetCell(field, Element);

            return new SetFieldElementCommand(field, Element, targetCell);
        }
    }
}
