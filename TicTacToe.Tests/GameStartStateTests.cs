using TicTacToeGame.Enums;
using TicTacToeGame.Input;
using TicTacToeGame.Players;
using TicTacToeGame.States;
using Moq;
using NUnit.Framework;

namespace TicTacToeGame.Tests
{
    [TestFixture]
    public class GameStartStateTests
    {
        public static GameStartState State;

        [SetUp]
        public static void InitializeState()
        {
            State = new GameStartState();
        }

        [Test]
        public void Enter_NullParameters_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => State.Enter(null));
        }

        [TestCase()]
        [TestCase(0,1)]
        [TestCase(0,1,2)]
        public void Enter_InvalidParametersLength_ThrowsArgumentException(params object[] parameters)
        {
            Assert.Throws<ArgumentException>(() => State.Enter(parameters));
        }

        [TestCase(0)]
        [TestCase("string")]
        [TestCase(3.5d)]
        public void Enter_InvalidParametersType_ThrowsArgumentException(params object[] parameters)
        {
            Assert.Throws<ArgumentException>(() => State.Enter(parameters));
        }

        [Test]
        public void Update_D1Pressed_SinglePlayerModeOn()
        {
            var mock = new Mock<IInputProcessor>();
            mock.Setup(m => m.GetKey()).Returns(ConsoleKey.D1);

            StateMachine.ChangeState(State, new Field(), mock.Object);

            State.Update();

            Assert.AreEqual(PlayerMode.SinglePlayer, State.Mode);
            Assert.IsInstanceOf(typeof(RealPlayer), State.Players[0]);
            Assert.IsInstanceOf(typeof(AIPlayer), State.Players[1]);
        }

        [Test]
        public void Update_D1Pressed_StateMachineOnTurnState()
        {
            var mock = new Mock<IInputProcessor>();
            mock.Setup(m => m.GetKey()).Returns(ConsoleKey.D1);

            StateMachine.ChangeState(State, new Field(), mock.Object);

            State.Update();

            Assert.IsInstanceOf(typeof(TurnState), StateMachine.CurrentState);
        }

        [Test]
        public void Update_D2Pressed_MultiPlayerModeOn()
        {
            var mock = new Mock<IInputProcessor>();
            mock.Setup(m => m.GetKey()).Returns(ConsoleKey.D2);

            StateMachine.ChangeState(State, new Field(), mock.Object);

            State.Update();

            Assert.AreEqual(PlayerMode.MultiPlayer, State.Mode);
            Assert.IsTrue(State.Players.All(p => p is RealPlayer));
        }

        [Test]
        public void Update_D2Pressed_StateMachineOnTurnState()
        {
            var mock = new Mock<IInputProcessor>();
            mock.Setup(m => m.GetKey()).Returns(ConsoleKey.D2);

            StateMachine.ChangeState(State, new Field(), mock.Object);

            State.Update();

            Assert.IsInstanceOf(typeof(TurnState), StateMachine.CurrentState);
        }

        [TestCase(ConsoleKey.A)]
        [TestCase(ConsoleKey.J)]
        [TestCase(ConsoleKey.D3)]
        [TestCase(ConsoleKey.Enter)]
        public void Update_AnyButtonExceptD1D2Pressed_StateMachineOnGameStartState(ConsoleKey key)
        {
            var mock = new Mock<IInputProcessor>();
            mock.Setup(m => m.GetKey()).Returns(key);

            StateMachine.ChangeState(State, new Field(), mock.Object);

            State.Update();

            Assert.IsInstanceOf(typeof(GameStartState), StateMachine.CurrentState);
        }

        [Test]
        public void Render_SelectModeStringIsRenderedOnConsole()
        {
            var trueResult = "Please select a game mode.\nPress '1' for SinglePlayer.\nPress '2' for MultiPlayer\r\n";

            var mock = new Mock<IInputProcessor>();

            State.Enter(new Field(), mock.Object);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            State.Render();

            var output = stringWriter.ToString();

            Assert.AreEqual(trueResult, output);
        }
    }
}
