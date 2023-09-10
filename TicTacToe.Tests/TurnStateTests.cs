using TicTacToeGame.AIStrategies;
using TicTacToeGame.Enums;
using TicTacToeGame.Input;
using TicTacToeGame.Players;
using TicTacToeGame.States;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Tests
{
    [TestFixture]
    public class TurnStateTests
    {

        public static Field FullField
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

        public static Field NearlyFullField
        {
            get
            {
                var field = new Field();
                field[(0, 0)] = Element.Cross;
                field[(0, 1)] = Element.Circle;
                field[(0, 2)] = Element.Cross;
                field[(1, 0)] = Element.Circle;
                field[(1, 2)] = Element.Circle;
                field[(2, 0)] = Element.Cross;
                field[(2, 1)] = Element.Circle;
                field[(2, 2)] = Element.Cross;

                return field;
            }
        }

        public static TurnState State;

        [SetUp]
        public void InitializeState()
        {
            State = new TurnState();
        }

        [Test]
        public void Enter_NullParameters_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => State.Enter(null));
        }

        [TestCase()]
        [TestCase(1)]
        [TestCase(1,2)]
        [TestCase(1,2,3)]
        [TestCase(1,2,3,4,5)]
        public void Enter_InvalidParametersLength_ThrowsArgumentException(params object[] parameters)
        {
            Assert.Throws<ArgumentException>(() => State.Enter(parameters));
        }

        [TestCase("","","","")]
        [TestCase("",2,"",1)]
        public void Enter_InvalidParametersType_ThrowsArgumentException(params object[] parameters)
        {
            Assert.Throws<ArgumentException>(() => State.Enter(parameters));
        }

        [Test]
        public void Update_AIPlayerBecomesWinner_StateMachineOnGameOverState()
        {
            var inputProcessorMock = new Mock<IInputProcessor>();

            Player[] players = new Player[2];
            players[0] = new RealPlayer(inputProcessorMock.Object);
            players[1] = new AIPlayer() { Element = Element.Cross, Strategy = new AIRandomStrategy() };

            int currentPlayerIndex = 1;

            State.Enter(NearlyFullField, players, currentPlayerIndex, inputProcessorMock.Object);

            State.Update();

            Assert.IsInstanceOf(typeof(GameOverState), StateMachine.CurrentState);
        }

        [Test]
        public void Update_AIPlayerMakesNonWinningTurn_StateMachineGoesToNewTurnState()
        {
            var inputProcessorMock = new Mock<IInputProcessor>();

            Player[] players = new Player[2];
            players[0] = new RealPlayer(inputProcessorMock.Object);
            players[1] = new AIPlayer() { Element = Element.Cross, Strategy = new AIRandomStrategy() };

            Field field = new Field();
            int currentPlayerIndex = 1;

            State.Enter(field, players, currentPlayerIndex, inputProcessorMock.Object);

            State.Update();

            Assert.IsInstanceOf(typeof(TurnState), StateMachine.CurrentState);
            Assert.AreNotSame(State, StateMachine.CurrentState);

        }

        [Test]
        public void Update_PlayerMakesNonWinningValidTurn_StateMachineGoesToNewTurnState()
        {
            var inputProcessorMock = new Mock<IInputProcessor>();

            Player[] players = new Player[2];
            players[0] = new RealPlayer(inputProcessorMock.Object) { Element = Element.Cross };
            players[1] = new AIPlayer() { Element = Element.Circle, Strategy = new AIRandomStrategy() };

            Field field = new Field();
            int currentPlayerIndex = 0;

            State.Enter(field, players, currentPlayerIndex, inputProcessorMock.Object);

            State.Update();

            Assert.IsInstanceOf(typeof(TurnState), StateMachine.CurrentState);
            Assert.AreNotSame(State, StateMachine.CurrentState);
        }

        [Test]
        public void Update_PlayerMakesWinningTurn_StateMachineOnGameOverState()
        {
            var inputProcessorMock = new Mock<IInputProcessor>();
            inputProcessorMock.Setup(m => m.GetKey()).Returns(ConsoleKey.D5);

            Player[] players = new Player[2];
            players[0] = new RealPlayer(inputProcessorMock.Object) { Element = Element.Cross };
            players[1] = new AIPlayer() { Element = Element.Circle, Strategy = new AIRandomStrategy() };

            int currentPlayerIndex = 0;

            State.Enter(NearlyFullField, players, currentPlayerIndex, inputProcessorMock.Object);

            State.Update();

            Assert.IsInstanceOf(typeof(GameOverState), StateMachine.CurrentState);
        }

        [TestCase(ConsoleKey.D1)]
        [TestCase(ConsoleKey.D2)]
        [TestCase(ConsoleKey.D3)]
        [TestCase(ConsoleKey.D4)]
        [TestCase(ConsoleKey.D6)]
        [TestCase(ConsoleKey.D7)]
        [TestCase(ConsoleKey.D8)]
        [TestCase(ConsoleKey.D9)]
        public void Update_PlayerSelectsNonEmptyFieldCell_StateDoesNotChange(ConsoleKey key)
        {
            var inputProcessorMock = new Mock<IInputProcessor>();
            inputProcessorMock.Setup(m => m.GetKey()).Returns(key);

            Player[] players = new Player[2];
            players[0] = new RealPlayer(inputProcessorMock.Object) { Element = Element.Cross };
            players[1] = new AIPlayer() { Element = Element.Circle, Strategy = new AIRandomStrategy() };

            int currentPlayerIndex = 0;

            StateMachine.ChangeState(
                state: State,
                NearlyFullField,
                players,
                currentPlayerIndex,
                inputProcessorMock.Object);

            State.Update();

            Assert.IsInstanceOf(typeof(TurnState), StateMachine.CurrentState);
            Assert.AreSame(State, StateMachine.CurrentState);
        }

        [TestCase(ConsoleKey.N)]
        [TestCase(ConsoleKey.A)]
        [TestCase(ConsoleKey.F12)]
        [TestCase(ConsoleKey.Backspace)]
        [TestCase(ConsoleKey.Enter)]
        [TestCase(ConsoleKey.Escape)]
        public void Update_PlayerPressesAnyKeyExceptDigits_StateDoesNotChange(ConsoleKey key)
        {
            var inputProcessorMock = new Mock<IInputProcessor>();
            inputProcessorMock.Setup(m => m.GetKey()).Returns(key);

            Player[] players = new Player[2];
            players[0] = new RealPlayer(inputProcessorMock.Object) { Element = Element.Cross };
            players[1] = new AIPlayer() { Element = Element.Circle, Strategy = new AIRandomStrategy() };

            int currentPlayerIndex = 0;

            StateMachine.ChangeState(
                state: State,
                NearlyFullField,
                players,
                currentPlayerIndex,
                inputProcessorMock.Object);

            State.Update();

            Assert.IsInstanceOf(typeof(TurnState), StateMachine.CurrentState);
            Assert.AreSame(State, StateMachine.CurrentState);
        }

        [Test]
        public void Render_CorrectField_FieldIsRenderedAfterNewLine()
        {
            var inputProcessorMock = new Mock<IInputProcessor>();

            string trueResult = "\r\n|X|O|X|\r\n|O|X|O|\r\n|X|O|X|\r\n";

            State.Enter(FullField, new Player[2], 0, inputProcessorMock.Object);

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            State.Render();

            var output = stringWriter.ToString();

            Assert.AreEqual(trueResult, output);
        }
    }
}
