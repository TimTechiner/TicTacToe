using TicTacToeGame.Enums;
using TicTacToeGame.Input;
using TicTacToeGame.States;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Tests
{
    [TestFixture]
   public class GameOverStateTests
    {
        public static List<TestCaseData> TestCases = new List<TestCaseData>()
        {
            new TestCaseData(new Field(), WinOutcome.None, "| | | |\r\n| | | |\r\n| | | |\r\nWinner is None\r\nPress R to restart a game\r\n"),
            new TestCaseData(new Field(), WinOutcome.Cross, "| | | |\r\n| | | |\r\n| | | |\r\nWinner is Cross\r\nPress R to restart a game\r\n"),
            new TestCaseData(new Field(), WinOutcome.Circle, "| | | |\r\n| | | |\r\n| | | |\r\nWinner is Circle\r\nPress R to restart a game\r\n"),
            new TestCaseData(new Field(), WinOutcome.Draw, "| | | |\r\n| | | |\r\n| | | |\r\nWinner is Draw\r\nPress R to restart a game\r\n"),
            new TestCaseData(Field, WinOutcome.Cross, "|X|O|X|\r\n|O|X|O|\r\n|X|O|X|\r\nWinner is Cross\r\nPress R to restart a game\r\n"),
        };

        public static Field Field
        {
            get
            {
                var field = new Field();
                field[(0, 0)] = Element.Cross;
                field[(0, 1)] = Element.Circle;
                field[(0, 2)] = Element.Cross;
                field[(1, 0)] = Element.Circle;
                field[(1, 1)] = Element.Cross;
                field[(1, 2)] = Element.Circle;
                field[(2, 0)] = Element.Cross;
                field[(2, 1)] = Element.Circle;
                field[(2, 2)] = Element.Cross;

                return field;
            }
        }

        public static GameOverState State;

        [SetUp]
        public void InitializeState()
        {
            State = new GameOverState();
        }

        [Test]
        public void Enter_NullParameters_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => State.Enter(null));
        }

        [TestCase()]
        [TestCase(1)]
        [TestCase(1,2)]
        [TestCase(1,2,3,4)]
        public void Enter_InvalidParametersLength_ThrowsArgumentException(params object[] parameters)
        {
            Assert.Throws<ArgumentException>(() => State.Enter(parameters));
        }

        [TestCase(0, 1, 1)]
        [TestCase(0, "string", "")]
        [TestCase(WinOutcome.None, "string", 2)]
        public void Enter_InvalidParametersType_ThrowsArgumentException(params object[] parameters)
        {
            Assert.Throws<ArgumentException>(() => State.Enter(parameters));
        }

        [Test]
        public void Update_RestartButtonPressed_StateMachineChangedStateToGameStartState()
        {
            var inputProcessorMock = new Mock<IInputProcessor>();
            inputProcessorMock.Setup(x => x.GetKey()).Returns(ConsoleKey.R);

            State.Enter(WinOutcome.Draw, new Field(), inputProcessorMock.Object);

            State.Update();

            Assert.IsInstanceOf(typeof(GameStartState), StateMachine.CurrentState);
        }

        [TestCase(ConsoleKey.D1)]
        [TestCase(ConsoleKey.Enter)]
        [TestCase(ConsoleKey.S)]
        [TestCase(ConsoleKey.F12)]
        public void Update_AnyButtonPressedExceptRestart_StateMachineOnGameOverState(ConsoleKey key)
        {
            var inputProcessorMock = new Mock<IInputProcessor>();
            inputProcessorMock.Setup(x => x.GetKey()).Returns(key);

            StateMachine.ChangeState(State, WinOutcome.Draw, new Field(), inputProcessorMock.Object);

            State.Update();

            Assert.IsInstanceOf(typeof(GameOverState), StateMachine.CurrentState);
        }
        
        [TestCaseSource(nameof(TestCases))]
        public void Render_CorrectParameters_CorrectConsoleOutput(Field field, WinOutcome winner, string trueResult)
        {
            State.Enter(winner, field, null);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            State.Render();

            var output = stringWriter.ToString();

            Assert.AreEqual(trueResult, output);
        }
    }
}
