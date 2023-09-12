namespace TicTacToeGame.Input
{
    public class InputProcessor : IInputProcessor
    {
        public ConsoleKey GetKey()
        {
            var key = Console.ReadKey(false).Key;
            Console.WriteLine();
            return key;
        }
    }
}
