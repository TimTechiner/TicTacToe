using TicTacToeGame.Enums;

namespace TicTacToeGame.AIStrategies
{
    public interface IPlayStrategy
    {
        public (int,int) GetNextTargetCell(Field field, Element elementAI);
    }
}
