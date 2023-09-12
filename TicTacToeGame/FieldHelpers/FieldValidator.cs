using TicTacToeGame.CustomExceptions;
using TicTacToeGame.Enums;

namespace TicTacToeGame.FieldHelpers
{
    public static class FieldValidator
    {
        private static Dictionary<Element, WinOutcome> ElementWon = new Dictionary<Element, WinOutcome>()
        {
            [Element.Cross] = WinOutcome.Cross,
            [Element.Circle] = WinOutcome.Circle,
            [Element.None] = WinOutcome.None,
        };

        public static WinOutcome GetWinner(Field field)
        {
            var rowWinner = GetWinnerByRows(field);

            var columnWinner = GetWinnerByColumns(field);

            var mainDiagonalWinner = GetMainDiagonalWinner(field);

            var antiDiagonalWinner = GetAntiDiagonalWinner(field);

            var winners = new List<WinOutcome>()
            {
                rowWinner,
                columnWinner,
                mainDiagonalWinner,
                antiDiagonalWinner
            }
                .Where(w => w != WinOutcome.None);

            var winner = TryGetWinnerFromWinners(winners, field);

            return winner;
        }

        public static WinOutcome GetAlmostWinnerByRow(Field field, int rowIndex)
        {
            return GetAlmostWinnerByVector(rowIndex, field.GetRow);
        }

        public static WinOutcome GetAlmostWinnerByColumn(Field field, int columnIndex)
        {
            return GetAlmostWinnerByVector(columnIndex, field.GetColumn);
        }

        public static WinOutcome GetAlmostWinnerByMainDiagonal(Field field)
        {
            Func<int, IEnumerable<Element>> getMainDiagonal = (int x) => field.GetMainDiagonal();
            return GetAlmostWinnerByVector(-1, getMainDiagonal);
        }

        public static WinOutcome GetAlmostWinnerByAntiDiagonal(Field field)
        {
            Func<int, IEnumerable<Element>> getAntiDiagonal = (int x) => field.GetAntiDiagonal();
            return GetAlmostWinnerByVector(-1, getAntiDiagonal);
        }

        private static WinOutcome GetAlmostWinnerByVector(int vectorIndex, Func<int, IEnumerable<Element>> getVector)
        {
            var vector = getVector(vectorIndex);

            int crossNumber = vector.Count(e => e == Element.Cross);
            int circleNumber = vector.Count(e => e == Element.Circle);

            if (crossNumber == 0 && circleNumber == 2) return WinOutcome.Circle;
            else if (crossNumber == 2 && circleNumber == 0) return WinOutcome.Cross;
            else return WinOutcome.None;
        }

        private static WinOutcome GetWinnerByRows(Field field)
        {
            return GetWinnerByVectors(field.Size, field.GetRow);
        }

        private static WinOutcome GetWinnerByColumns(Field field)
        {
            return GetWinnerByVectors(field.Size, field.GetColumn);
        }

        private static WinOutcome GetWinnerByVectors(int fieldSize, Func<int, IEnumerable<Element>> getVector)
        {
            WinOutcome winner = WinOutcome.None;

            for (int i = 0; i < fieldSize; i++)
            {
                var vector = getVector(i);
                var newWinner = GetVectorWinner(vector);

                if (newWinner == WinOutcome.Cross || newWinner == WinOutcome.Circle)
                {
                    winner = TryGetWinnerFromWinners(new List<WinOutcome>() { winner, newWinner }.Where(w => w != WinOutcome.None));
                }
            }

            return winner;
        }

        private static WinOutcome GetVectorWinner(IEnumerable<Element> vector)
        {
            Element firstVectorElement = vector.FirstOrDefault();

            foreach (var element in vector)
            {
                if (firstVectorElement != element) return WinOutcome.None;
            }

            return ElementWon[firstVectorElement];
        }

        private static WinOutcome GetDiagonalWinner(IEnumerable<Element> diagonal)
        {
            var firstElement = diagonal.FirstOrDefault();

            if (diagonal.All(e => e == firstElement)) return ElementWon[firstElement];
            else return WinOutcome.None;
        }

        private static WinOutcome GetMainDiagonalWinner(Field field)
        {
            return GetDiagonalWinner(field.GetMainDiagonal());
        }

        private static WinOutcome GetAntiDiagonalWinner(Field field)
        {
            return GetDiagonalWinner(field.GetAntiDiagonal());
        }

        private static WinOutcome TryGetWinnerFromWinners(IEnumerable<WinOutcome> winners)
        {
            var winner = WinOutcome.Draw;

            if (winners.Any())
            {
                if (winners.All(w => w == winners.FirstOrDefault()))
                    winner = winners.FirstOrDefault();
                else
                    throw new FieldInvalidException("Field is incorrect");
            }

            return winner;
        }

        private static WinOutcome TryGetWinnerFromWinners(IEnumerable<WinOutcome> winners, Field field)
        {
            var winner = TryGetWinnerFromWinners(winners);

            if (!field.IsFilled && winner == WinOutcome.Draw)
            {
                winner = WinOutcome.None;
            }

            return winner;
        }
    }
}
