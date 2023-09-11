using TicTacToeGame.AIStrategies;
using TicTacToeGame.CustomExceptions;
using TicTacToeGame.Enums;
using TicTacToeGame.Input;
using TicTacToeGame.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.States
{
    public class GameStartState : BaseState
    {
        private const int N_PLAYERS = 2;
        private const string SELECT_MODE_STRING = "Please select a game mode.\nPress '1' for SinglePlayer.\nPress '2' for MultiPlayer";
        private Field field;
        private Player[] players;
        private PlayerMode mode;
        private int firstPlayerIndex;
        private IInputProcessor inputProcessor;

        public Player[] Players => players;
        public PlayerMode Mode => mode;

        public override void Enter(params object[] parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Length != 2)
            {
                throw new ArgumentException(nameof(parameters));
            }

            if (parameters[0] is not Field || parameters[1] is not IInputProcessor)
            {
                throw new ArgumentException(nameof(parameters));
            }

            field = (Field)parameters[0];
            inputProcessor = (IInputProcessor)parameters[1];

            field.Reset();
            players = new Player[N_PLAYERS];

            Render();
        }

        public override void Update()
        {
            var key = inputProcessor.GetKey();

            if (key == ConsoleKey.D1 || key == ConsoleKey.D2)
            {
                mode = (key == ConsoleKey.D1) ? PlayerMode.SinglePlayer : PlayerMode.MultiPlayer;

                InitializePlayers();
                SetPlayersElements();
                SetFirstPlayer();
                StateMachine.ChangeState(new TurnState(), field, players, firstPlayerIndex, inputProcessor);
            }
        }

        public override void Render()
        {
            Console.WriteLine(SELECT_MODE_STRING);
        }

        private void InitializePlayers()
        {
            switch (mode)
            {
                case PlayerMode.SinglePlayer:
                    players[0] = new RealPlayer(inputProcessor);
                    players[1] = new AIPlayer() { Strategy = new AISmartStrategy() };
                    break;
                case PlayerMode.MultiPlayer:
                    players[0] = new RealPlayer(inputProcessor);
                    players[1] = new RealPlayer(inputProcessor);
                    break;
                default:
                    throw new PlayerModeInvalidException("Player Mode is not Recognized");
            }
        }

        private void SetPlayersElements()
        {
            var crossPlayerIndex = Random.Shared.Next(0, N_PLAYERS);
            var circlePlayerIndex = Enumerable.Range(0, N_PLAYERS).FirstOrDefault(e => e != crossPlayerIndex);

            players[crossPlayerIndex].Element = Element.Cross;
            players[circlePlayerIndex].Element = Element.Circle;
        }

        private void SetFirstPlayer()
        {
            firstPlayerIndex = Random.Shared.Next(0, N_PLAYERS);
        }
    }
}
