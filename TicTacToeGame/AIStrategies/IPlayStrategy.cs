using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Enums;

namespace TicTacToeGame.AIStrategies
{
    public interface IPlayStrategy
    {
        public (int,int) GetNextTargetCell(Field field, Element elementAI);
    }
}
