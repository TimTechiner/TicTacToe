using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Command;
using TicTacToeGame.Enums;
using TicTacToeGame.Input;
using TicTacToeGame.States;

namespace TicTacToeGame.Tests
{
    [TestFixture]
    public class SetFieldElementCommandTests
    {
        [Test]
        public void Constructor_NullField_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new SetFieldElementCommand(null, Element.None, (0,0)));
        }

        [Test]
        public void Execute_CommandExecutedSetToEmptyCell_FieldChanged()
        {
            Field field = new Field();
            Element element = Element.Cross;
            var position = (0, 0);
            SetFieldElementCommand command = new SetFieldElementCommand(field, element, position);

            command.Execute();

            Assert.AreEqual(field[position], element);
        }

        [Test]
        public void Execute_SetToFilledCell_FieldDoesNotChange()
        {
            Field field = new Field();
            Element element = Element.Circle;
            var position = (0, 0);
            var trueElement = Element.Cross;
            var trueFreeCellsNumber = 8;
            field[position] = trueElement;
            SetFieldElementCommand command = new SetFieldElementCommand(field, element, position);

            command.Execute();

            Assert.AreEqual(field[position], Element.Cross);
            Assert.AreEqual(trueFreeCellsNumber, field.GetFreeCells().Count());
        }
    }
}
