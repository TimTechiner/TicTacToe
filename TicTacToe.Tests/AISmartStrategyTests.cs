using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.AIStrategies;
using TicTacToeGame.CustomExceptions;
using TicTacToeGame.Enums;

namespace TicTacToeGame.Tests
{
    [TestFixture]
    public class AISmartStrategyTests
    {
        private static AISmartStrategy Strategy = new AISmartStrategy();

        public static IEnumerable<TestCaseData> GetFieldsWinningPositionsWithNextTargetCells()
        {
            return new List<TestCaseData>()
            {
                new TestCaseData(FieldsWithAIAlmostWinner[0], Element.Cross, (1,1)),
                new TestCaseData(FieldsWithAIAlmostWinner[1], Element.Cross, (0,2)),
                new TestCaseData(FieldsWithAIAlmostWinner[2], Element.Cross, (1,1)),
                new TestCaseData(FieldsWithAIAlmostWinner[3], Element.Circle, (2,0)),
                new TestCaseData(FieldsWithAIAlmostWinner[4], Element.Cross, (2,0)),
                new TestCaseData(FieldsWithAIAlmostWinner[5], Element.Circle, (2,2)),
            };
        }

        private static List<Field> FieldsWithAIAlmostWinner = new List<Field>()
        {
            //|X| | |
            //| | | |
            //| | |X|
            FieldGenerator.GenerateFieldByCellOneDimensionalIndices(
                new List<(int, Element)>()
                {
                    (0, Element.Cross),
                    (8, Element.Cross),
                }
            ),

            //|X|X| |
            //| | | |
            //| | | |
            FieldGenerator.GenerateFieldByCellOneDimensionalIndices(
                new List<(int, Element)>()
                {
                    (0, Element.Cross),
                    (1, Element.Cross),
                }
            ),

            //| | | |
            //|X| |X|
            //| | | |
            FieldGenerator.GenerateFieldByCellOneDimensionalIndices(
                new List<(int, Element)>()
                {
                    (3, Element.Cross),
                    (5, Element.Cross),
                }
            ),

            //| | |O|
            //| |O| |
            //| | | |
            FieldGenerator.GenerateFieldByCellOneDimensionalIndices(
                new List<(int, Element)>()
                {
                    (2, Element.Circle),
                    (4, Element.Circle),
                }
            ),

            //|X| |O|
            //|X| |O|
            //| | | |
            FieldGenerator.GenerateFieldByCellOneDimensionalIndices(
                new List<(int, Element)>()
                {
                    (0, Element.Cross),
                    (3, Element.Cross),
                    (2, Element.Circle),
                    (5, Element.Circle),
                }
            ),

            //|X|X|O|
            //|X| |O|
            //| | | |
            FieldGenerator.GenerateFieldByCellOneDimensionalIndices(
                new List<(int, Element)>()
                {
                    (0, Element.Cross),
                    (1, Element.Cross),
                    (3, Element.Cross),
                    (2, Element.Circle),
                    (5, Element.Circle),
                }
            ),
        };

        public static IEnumerable<TestCaseData> GetFieldsWithPlayerAlmostWinnerPositions()
        {
            return new List<TestCaseData>()
            {
                new TestCaseData(FieldsWithPlayerAlmostWinner[0], Element.Cross, (2,2)),
                new TestCaseData(FieldsWithPlayerAlmostWinner[1], Element.Circle, (1,1)),
                new TestCaseData(FieldsWithPlayerAlmostWinner[2], Element.Circle, (2,0)),
                new TestCaseData(FieldsWithPlayerAlmostWinner[3], Element.Circle, (2,2)),
            };
        }

        private static List<Field> FieldsWithPlayerAlmostWinner = new List<Field>()
        {
            //|X| |O|
            //| | |O|
            //| | | |
            FieldGenerator.GenerateFieldByCellOneDimensionalIndices(
                new List<(int, Element)>()
                {
                    (0, Element.Cross),
                    (2, Element.Circle),
                    (5, Element.Circle),
                }),

            //|X|O| |
            //| | | |
            //| | |X|
            FieldGenerator.GenerateFieldByCellOneDimensionalIndices(
                new List<(int, Element)>()
                {
                    (0, Element.Cross),
                    (8, Element.Cross),
                    (1, Element.Circle),
                }),

            //|X|X|O|
            //|X| | |
            //| |O| |
            FieldGenerator.GenerateFieldByCellOneDimensionalIndices(
                new List<(int, Element)>()
                {
                    (0, Element.Cross),
                    (1, Element.Cross),
                    (3, Element.Cross),
                    (2, Element.Circle),
                    (7, Element.Circle),
                }),

            //|X|O|X|
            //| |X| |
            //|O| | |
            FieldGenerator.GenerateFieldByCellOneDimensionalIndices(
                new List<(int, Element)>()
                {
                    (0, Element.Cross),
                    (2, Element.Cross),
                    (4, Element.Cross),
                    (1, Element.Circle),
                    (6, Element.Circle),
                }),
        };

        [Test]
        public void GetNextTargetCell_NullField_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => Strategy.GetNextTargetCell(null, Element.Cross));
        }

        [Test]
        public void GetNextTargetCell_ElementNone_ThrowsPlayableElementException()
        {
            var field = new Field();
            Assert.Throws<PlayableElementException>(
                () => Strategy.GetNextTargetCell(field, Enums.Element.None));
        }

        [Test]
        public void GetNextTargetCell_FilledField_ThrowsFieldFilledException()
        {
            var field = FieldGenerator.GenerateFilledFields(1).FirstOrDefault();

            Assert.Throws<FieldFilledException>(
                () => Strategy.GetNextTargetCell(field, Enums.Element.Cross));
        }

        [TestCaseSource(nameof(GetFieldsWinningPositionsWithNextTargetCells))]
        public void GetNextTargetCell_FieldsWithAIWinningPlaces_ReturnsWinningPlace(
            Field field, 
            Element elementAI, 
            (int,int) trueResult)
        {
            var result = Strategy.GetNextTargetCell(field, elementAI);

            Assert.AreEqual(trueResult, result);
        }

        [TestCaseSource(nameof(GetFieldsWithPlayerAlmostWinnerPositions))]
        public void GetNextTargetCell_FieldsWithPlayerWinningPlaces_ReturnsPlayerWinningPlace(
            Field field,
            Element elementAI,
            (int,int) trueResult)
        {
            var result = Strategy.GetNextTargetCell(field, elementAI);

            Assert.AreEqual(trueResult, result);
        }
    }
}
