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
        private static IEnumerable<Field> FilledFields = FieldGenerator.GenerateFilledFields(10);

        private static IEnumerable<Field> EmptyFields =
            FieldGenerator.GenerateNotFilledFields(10, 5)
            .Concat(FieldGenerator.GenerateNotFilledFields(10, 3));

        private static IEnumerable<TestCaseData> FieldsWithFreeCells = new List<TestCaseData>()
        {
            new TestCaseData(FieldGenerator.GenerateNotFilledFields(1, 1).FirstOrDefault(), 1),
            new TestCaseData(FieldGenerator.GenerateNotFilledFields(1, 2).FirstOrDefault(), 2),
            new TestCaseData(FieldGenerator.GenerateNotFilledFields(1, 3).FirstOrDefault(), 3),
            new TestCaseData(FieldGenerator.GenerateNotFilledFields(1, 4).FirstOrDefault(), 4),
            new TestCaseData(FieldGenerator.GenerateNotFilledFields(1, 5).FirstOrDefault(), 5),
            new TestCaseData(FieldGenerator.GenerateNotFilledFields(1, 6).FirstOrDefault(), 6),
            new TestCaseData(FieldGenerator.GenerateNotFilledFields(1, 7).FirstOrDefault(), 7),
            new TestCaseData(FieldGenerator.GenerateNotFilledFields(1, 8).FirstOrDefault(), 8),
        };
        

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

        [TestCaseSource(nameof(EmptyFields))]
        public void IsFilled_NotFilledFields_ReturnsFalse(Field field)
        {
            Assert.IsFalse(field.IsFilled);
        }

        [TestCaseSource(nameof(FieldsWithFreeCells))]
        public void GetFreeCells_FieldsContainFreeCells_ReturnsNoneCells(Field field, int freeCellsNumber)
        {
            var freeCells = field.GetFreeCells();

            Assert.AreEqual(freeCellsNumber, freeCells.Count());
        }

        [TestCaseSource(nameof(FilledFields))]
        public void GetRow_GetFieldRows_ReturnCorrectRow(Field field)
        {
            var expectedFirstRow = Enumerable.Range(0, field.Size).Select(e => field[(0,e)]);
            var expectedSecondRow = Enumerable.Range(0, field.Size).Select(e => field[(1,e)]);
            var expectedThirdRow = Enumerable.Range(0, field.Size).Select(e => field[(2,e)]);

            var firstRow = field.GetRow(0);
            var secondRow = field.GetRow(1);
            var thirdRow = field.GetRow(2);

            Assert.AreEqual(expectedFirstRow, firstRow);
            Assert.AreEqual(expectedSecondRow, secondRow);
            Assert.AreEqual(expectedThirdRow, thirdRow);
        }

        [TestCaseSource(nameof(FilledFields))]
        public void GetColumn_GetFieldColumns_ReturnCorrectColumn(Field field)
        {
            var expectedFirstColumn = Enumerable.Range(0, field.Size).Select(e => field[(e, 0)]);
            var expectedSecondColumn = Enumerable.Range(0, field.Size).Select(e => field[(e, 1)]);
            var expectedThirdColumn = Enumerable.Range(0, field.Size).Select(e => field[(e, 2)]);

            var firstColumn = field.GetColumn(0);
            var secondColumn = field.GetColumn(1);
            var thirdColumn = field.GetColumn(2);

            Assert.AreEqual(expectedFirstColumn, firstColumn);
            Assert.AreEqual(expectedSecondColumn, secondColumn);
            Assert.AreEqual(expectedThirdColumn, thirdColumn);
        }

        [TestCaseSource(nameof(FilledFields))]
        public void GetMainDiagonal_GetFilledFieldsDiagonal_ReturnCorrectDiagonal(Field field)
        {
            var expectedDiagonal = Enumerable.Range(0, field.Size).Select(e => field[(e, e)]);

            var diagonal = field.GetMainDiagonal();

            Assert.AreEqual(expectedDiagonal, diagonal);
        }

        [TestCaseSource(nameof(FilledFields))]
        public void GetAntiDiagonal_GetFilledFieldsDiagonal_ReturnCorrectDiagonal(Field field)
        {
            var expectedDiagonal = Enumerable.Range(0, field.Size).Select(e => field[(field.Size - 1 - e, e)]);

            var diagonal = field.GetAntiDiagonal();

            Assert.AreEqual(expectedDiagonal, diagonal);
        }

    }
}
