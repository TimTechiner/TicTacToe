using TicTacToeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.AIStrategies
{
    public class AIRandomStrategy : IPlayStrategy
    {
        public (int, int) GetNextTargetCell(Field field, Element elementAI)
        {
            var freeCells = field.GetFreeCells();

            if (freeCells.Count() == 0)
            {
                throw new Exception("Field is already filled");
            }

            var index = Random.Shared.Next(freeCells.Count());
            var randomFreeCell = freeCells.ToList()[index];

            return randomFreeCell;
        }
    }
}
