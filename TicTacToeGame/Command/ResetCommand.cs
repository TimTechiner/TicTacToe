﻿using TicTacToeGame.Input;
using TicTacToeGame.States;

namespace TicTacToeGame.Command
{
    public class ResetCommand : ICommand
    {
        private readonly Field field;
        private readonly IInputProcessor inputProcessor;

        public ResetCommand(Field field, IInputProcessor inputProcessor)
        {
            this.field = field;
            this.inputProcessor = inputProcessor;
        }

        public void Execute()
        {
            StateMachine.ChangeState(new GameStartState(), field, inputProcessor);
        }
    }
}
