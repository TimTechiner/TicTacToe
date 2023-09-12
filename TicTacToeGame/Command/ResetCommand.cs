using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Input;
using TicTacToeGame.States;

namespace TicTacToeGame.Command
{
    public class ResetCommand : ICommand
    {
        private Field field;
        private IInputProcessor inputProcessor;

        public ResetCommand(Field field, IInputProcessor inputprocessor)
        {
            this.field = field;
            this.inputProcessor = inputprocessor;
        }
        public void Execute()
        {
            StateMachine.ChangeState(new GameStartState(), field, inputProcessor);
        }
    }
}
