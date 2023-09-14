namespace TicTacToeGame.CustomExceptions
{
    public class PlayableElementException : Exception
    {
        public PlayableElementException() : base() { }
        public PlayableElementException(string message) : base(message) { }
    }
}
