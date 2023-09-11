﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Enums;
using TicTacToeGame.FieldHelpers;

namespace TicTacToeGame.AIStrategies
{
    public class AISmartStrategy : IPlayStrategy
    {
        private readonly static Dictionary<Element, WinOutcome> ElementWinnerMap = new Dictionary<Element, WinOutcome>()
        {
            [Element.Cross] = WinOutcome.Cross,
            [Element.Circle] = WinOutcome.Circle,
        };

        public (int, int) GetNextTargetCell(Field field, Element elementAI)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            var aiWinningPositions = GetAIWinningPositions(field, elementAI);
            var playerWinningPositions = GetPlayerWinningPositions(field, new List<Element>() { Element.Cross, Element.Circle }.FirstOrDefault(e => e != elementAI));
            var aiAlmostWinningPositions = GetAIAlmostWinningPositions(field, elementAI);

            if (aiWinningPositions.Count() != 0) return aiWinningPositions.FirstOrDefault();
            if (playerWinningPositions.Count() != 0) return playerWinningPositions.FirstOrDefault();
            if (aiAlmostWinningPositions.Count() != 0) return aiAlmostWinningPositions.FirstOrDefault();

            return new AIRandomStrategy().GetNextTargetCell(field, elementAI);
        }

        private IEnumerable<(int,int)> GetWinningPosition(Field field, Element element)
        {
            var freeCells = field.GetFreeCells();

            foreach (var freeCell in freeCells)
            {
                var potentialField = field.Clone() as Field;

                potentialField[freeCell] = element;

                var winner = FieldValidator.GetWinner(potentialField);

                if (ElementWinnerMap[element] == winner) yield return freeCell;
            }
        }

        private IEnumerable<(int,int)> GetAIWinningPositions(Field field, Element elementAI)
        {
            return GetWinningPosition(field, elementAI);
        }

        private IEnumerable<(int,int)> GetPlayerWinningPositions(Field field, Element elementPlayer)
        {
            return GetWinningPosition(field, elementPlayer);
        }

        private IEnumerable<(int,int)> GetAIAlmostWinningPositions(Field field, Element elementAI)
        {
            var freeCells = field.GetFreeCells();

            foreach (var freeCell in freeCells)
            {
                var potentialField = field.Clone() as Field;

                potentialField[freeCell] = elementAI;

                for (int i = 0; i < potentialField.Size; i++)
                {
                    var rowWinner = FieldValidator.GetAlmostWinnerByRow(potentialField, i);
                    if (ElementWinnerMap[elementAI] == rowWinner) yield return freeCell;

                    var columnWinner = FieldValidator.GetAlmostWinnerByColumn(potentialField, i);
                    if (ElementWinnerMap[elementAI] == columnWinner) yield return freeCell;
                }

                var mainDiagonalWinner = FieldValidator.GetAlmostWinnerByMainDiagonal(potentialField);
                if (ElementWinnerMap[elementAI] == mainDiagonalWinner) yield return freeCell;

                var antiDiagonalWinner = FieldValidator.GetAlmostWinnerByAntiDiagonal(potentialField);
                if (ElementWinnerMap[elementAI] == antiDiagonalWinner) yield return freeCell;
            }
        }
    }
}
