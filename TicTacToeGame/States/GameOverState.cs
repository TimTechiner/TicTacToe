using TicTacToeGame.Enums;
using TicTacToeGame.FieldHelpers;
using TicTacToeGame.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.States
{
    public class GameOverState : BaseState
    {
        private WinOutcome winner;
        private Field field;
        private IInputProcessor inputProcessor;

        private const string WINNER_SHOW_STRING = "Winner is {0}";
        private const string PRESS_TO_RESTART_STRING = "Press {0} to restart a game";
        private const string RESTART_BUTTON = "R";

        public override void Enter(params object[] parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Length != 3)
            {
                throw new ArgumentException(nameof(parameters));
            }

            if (parameters[0] is not WinOutcome || parameters[1] is not Field)
            {
                throw new ArgumentException(nameof(parameters));
            }

            winner = (WinOutcome)parameters[0];
            field = (Field)parameters[1];
            inputProcessor = (IInputProcessor)parameters[2];

            Render();
        }

        public override void Update()
        {
            var key = inputProcessor.GetKey();

            if (key == ConsoleKey.R)
            {
                StateMachine.ChangeState(new GameStartState(), field, inputProcessor);
            }
        }

        public override void Render()
        {
            FieldRenderer.RenderField(field);

            Console.WriteLine(String.Format(WINNER_SHOW_STRING, winner));
            Console.WriteLine(String.Format(PRESS_TO_RESTART_STRING, RESTART_BUTTON));
        }
    }
}
