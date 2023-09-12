namespace TicTacToeGame.CustomExceptions
{
    public class FieldInvalidException: Exception
    {
        public FieldInvalidException() { }
        public FieldInvalidException(string message) : base(message) { }
    }
}
