using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Command;
using TicTacToeGame.Input;
using TicTacToeGame.States;

namespace TicTacToeGame.Tests
{
    [TestFixture]
    public class ResetCommandTests
    {
        [Test]
        public void Constructor_NullField_ThrowsArgumentNullException()
        {
            var mock = new Mock<IInputProcessor>();

            Assert.Throws<ArgumentNullException>(() => new ResetCommand(null, mock.Object));
        }

        [Test]
        public void Constructor_NullInputProcessor_ThrowsArgumentNullException()
        {
            var field = new Field();

            Assert.Throws<ArgumentNullException>(() => new ResetCommand(field, null));
        }

        [Test]
        public void Execute_CommandExecuted_StateMachineOnGameStartState()
        {
            Field field = new Field();
            var mock = new Mock<IInputProcessor>();
            ResetCommand command = new ResetCommand(field, mock.Object);

            command.Execute();

            Assert.IsInstanceOf(typeof(GameStartState), StateMachine.CurrentState);
        }
    }
}
