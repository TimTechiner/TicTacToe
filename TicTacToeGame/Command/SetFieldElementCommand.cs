using TicTacToeGame.Enums;

namespace TicTacToeGame.Command
{
    public class SetFieldElementCommand : ICommand
    {
        private readonly Field field;
        private readonly Element element;
        private readonly (int, int) position;

        public SetFieldElementCommand(Field field, Element element, (int, int) position)
        {
            this.field = field;
            this.element = element;
            this.position = position;
        }

        public void Execute()
        {
            if (field[position] == Element.None)
            {
                field[position] = element;
            }
        }
    }
}
