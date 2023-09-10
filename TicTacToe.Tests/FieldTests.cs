using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Enums;

namespace TicTacToeGame.Tests
{
    [TestFixture]
    public class FieldTests
    {
        private static IEnumerable<Field> FilledFields = Enumerable
            .Range(0, 10)
            .Select(e => RandomFilledField);
        
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
                        field[(i,j)] = elements[Random.Shared.Next(elements.Count)];
                    }
                }
                return field;
            }
        }

        [Test]
        public void Contructor_InstanceCreated_FieldElementIsElementNone()
        {
            var field = new Field();

            Assert.IsTrue(field.IsEmpty);
        }

        [Test]
        public void Reset_CommonCall_FieldElementsAreNone()
        {
            var field = new Field();

            field[(0, 0)] = Enums.Element.Cross;

            Assert.IsFalse(field.IsEmpty);

            field.Reset();

            Assert.IsTrue(field.IsEmpty);
        }

        [TestCaseSource(nameof(FilledFields))]
        public void IsFilled_FilledFields_ReturnsTrue(Field field)
        {
            Assert.IsTrue(field.IsFilled);
        }

    }
}
