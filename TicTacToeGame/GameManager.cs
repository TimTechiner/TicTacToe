using TicTacToeGame.Input;
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
