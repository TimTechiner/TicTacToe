using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.AIStrategies;
using TicTacToeGame.Command;
using TicTacToeGame.CustomEventArgs;
using TicTacToeGame.CustomExceptions;
using TicTacToeGame.Enums;
using TicTacToeGame.Input;
using TicTacToeGame.Players;
using TicTacToeGame.States;

namespace TicTacToeGame
{
    public static class GameManager
    {
        private static bool isQuit = false;

        public static void RunGame()
        {
            StartGame();

            while (!isQuit)
            {
                Update();
            }
        }

        private static void StartGame()
        {
            var inputProcesor = new InputProcessor();
            var field = new Field();

            StateMachine.ChangeState(new GameStartState(), field, inputProcesor);
        }

        private static void Update()
        {
            StateMachine.Update();
        }
    }
}
