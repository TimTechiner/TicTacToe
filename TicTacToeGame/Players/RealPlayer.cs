using TicTacToeGame.Command;
using TicTacToeGame.Enums;
using TicTacToeGame.Input;

namespace TicTacToeGame.Players
{
    public class RealPlayer : Player
    {
        private static Dictionary<ConsoleKey, (int, int)> NumberCoordinatesMap = new()
        {
            [ConsoleKey.D1] = (0, 0),
            [ConsoleKey.D2] = (0, 1),
            [ConsoleKey.D3] = (0, 2),
            [ConsoleKey.D4] = (1, 0),
            [ConsoleKey.D5] = (1, 1),
            [ConsoleKey.D6] = (1, 2),
            [ConsoleKey.D7] = (2, 0),
            [ConsoleKey.D8] = (2, 1),
            [ConsoleKey.D9] = (2, 2),
        };

        private readonly IInputProcessor inputProcessor;

        public RealPlayer(IInputProcessor inputProcessor) : base()
        {
            this.inputProcessor = inputProcessor;
        }

        public override ICommand MakeTurn(Field field)
        {
            var key = inputProcessor.GetKey();

            if (NumberCoordinatesMap.ContainsKey(key))
            {
                var coordinates = NumberCoordinatesMap[key];
                if (field[coordinates] == Element.None)
                {
                    return new SetFieldElementCommand(field, Element, NumberCoordinatesMap[key]);
                }
                else
                {
                    return new EmptyCommand();
                }
            }
            else
            {
                return new EmptyCommand();
            }
        }
    }
}
