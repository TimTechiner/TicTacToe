namespace TicTacToeGame.CustomExceptions
{
    public class PlayerModeInvalidException: Exception
    {
        public PlayerModeInvalidException() { }
        public PlayerModeInvalidException(string message) : base(message) { }
    }
}
