using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Command;
using TicTacToeGame.CustomExceptions;
using TicTacToeGame.Players;

namespace TicTacToeGame.Tests
{
    [TestFixture]
    public class AIPlayerTests
    {
        private static AIPlayer player = new AIPlayer();

        [TearDown]
        public void SetElementToNone()
        {
            player.Element = Enums.Element.None;
        }

        [Test]
        public void StrategySet_NullValue_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => player.Strategy = null);
        }

        [Test]
        public void MakeTurn_NullField_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => player.MakeTurn(null));
        }

        [Test]
        public void MakeTurn_FilledField_ThrowsFieldFilledException()
        {
            var field = FieldGenerator.GenerateFilledFields(1).First();
            player.Element = Enums.Element.Cross;

            Assert.Throws<FieldFilledException>(() => player.MakeTurn(field));
        }

        [Test]
        public void MakeTurn_NonPlayableElement_ThrowsPlayableElementException()
        {
            var field = new Field();

            Assert.Throws<PlayableElementException>(() => player.MakeTurn(field));
        }

        [Test]
        public void MakeTurn_ValidField_ReturnsSetFieldElementCommand()
        {
            var field = new Field();
            player.Element = Enums.Element.Cross;

            var result = player.MakeTurn(field);

            Assert.IsInstanceOf(typeof(SetFieldElementCommand), result);
        }
    }
}
