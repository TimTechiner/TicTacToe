using TicTacToeGame.CustomExceptions;
using TicTacToeGame.Enums;

namespace TicTacToeGame.AIStrategies
{
    public class AIRandomStrategy : IPlayStrategy
    {
        public (int, int) GetNextTargetCell(Field field, Element elementAI)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (elementAI == Element.None)
            {
                throw new PlayableElementException($"AI cannot play with element : {elementAI}");
            }

            var freeCells = field.GetFreeCells();

            if (!freeCells.Any())
            {
                throw new FieldFilledException("Field is already filled");
            }

            var index = Random.Shared.Next(freeCells.Count());
            var randomFreeCell = freeCells.ToList()[index];

            return randomFreeCell;
        }
    }
}
