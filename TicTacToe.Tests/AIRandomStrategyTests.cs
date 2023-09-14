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
    public class AIRandomStrategyTests
    {
        public static AIRandomStrategy Strategy = new AIRandomStrategy();

        [Test]
        public void GetNextTargetCell_FieldIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Strategy.GetNextTargetCell(null, Element.Cross));
        }

        [Test]
        public void GetNextTargetCell_ElementNonePassed_ThrowsPlayableElementException()
        {
            var field = new Field();
            Assert.Throws<PlayableElementException>(() => Strategy.GetNextTargetCell(field, Element.None));
        }

        [Test]
        public void GetNextTargetCell_FilledFields_ThrowsFiledFilledException()
        {
            var field = FieldGenerator.GenerateFilledFields(1).FirstOrDefault();
            Assert.Throws<FieldFilledException>(() => Strategy.GetNextTargetCell(field, Element.Cross));
        }

        [Test]
        public void GetNextTargetCell_ValidFields_ReturnsCoordinatesBetweenZeroAndFieldSize()
        {
            var field = FieldGenerator.GenerateNotFilledFields(1, 5).FirstOrDefault();

            var result = Strategy.GetNextTargetCell(field, Element.Cross);

            Assert.Greater(result.Item1, -1);
            Assert.Less(result.Item1, field.Size);
            Assert.Less(result.Item2, field.Size);
            Assert.Greater(result.Item2, -1);
        }
    }
}
