using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Enums;

namespace TicTacToeGame.Tests
{
    public static class FieldGenerator
    {
        private static List<(int,int)> AllCellCoordinates = Enumerable
            .Range(0, Field.FIELDSIZE)
            .SelectMany(e1 => Enumerable.Range(0, Field.FIELDSIZE).Select(e2 => (e1, e2)))
            .ToList();

        public static IEnumerable<Field> GenerateEmptyFields(int count)
        {
            return Enumerable.Range(0, count).Select(e => new Field());
        }

        public static IEnumerable<Field> GenerateFilledFields(int count)
        {
            return Enumerable.Range(0, count).Select(e => RandomFilledField);
        }

        public static IEnumerable<Field> GenerateNotFilledFields(int count, int freeCellsNumber)
        {
            return Enumerable.Range(0, count)
                .Select(e => GenerateNotFilledField(freeCellsNumber));
        }

        private static Field GenerateNotFilledField(int freeCellsNumber)
        {
            var field = RandomFilledField;

            List<(int,int)> availableCellCoordinates = AllCellCoordinates.ToList();
            List<(int, int)> randomCoordinates = new List<(int, int)>();


            for (int i = 0; i < freeCellsNumber; i++)
            {
                var index = Random.Shared.Next(availableCellCoordinates.Count);
                var coordinates = availableCellCoordinates[index];

                randomCoordinates.Add(coordinates);

                availableCellCoordinates.Remove(coordinates);
            }

            foreach (var randomCoordinate in randomCoordinates)
            {
                field[randomCoordinate] = Element.None;
            }

            return field;
        }

        private static Field RandomFilledField
        {
            get
            {
                Field field = new Field();
                var elements = new List<Element>() { Element.Cross, Element.Circle };
                for (int i = 0; i < field.Size; i++)
                {
                    for (int j = 0; j < field.Size; j++)
                    {
                        field[(i, j)] = elements[Random.Shared.Next(elements.Count)];
                    }
                }
                return field;
            }
        }
    }
}
