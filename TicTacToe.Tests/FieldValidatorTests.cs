using TicTacToeGame.CustomExceptions;
using TicTacToeGame.Enums;
using TicTacToeGame.FieldHelpers;
using NUnit.Framework;

namespace TicTacToeGame.Tests
{
    [TestFixture]
    public class FieldValidatorTests
    {
        public static List<TestCaseData> NonWinningFieldsTestCases
        {
            get
            {
                InitializeCorrectNonWinnerFields();
                return new List<TestCaseData>()
                {
                    new TestCaseData(nonWinningFields[0], WinOutcome.None),
                    new TestCaseData(nonWinningFields[1], WinOutcome.None),
                    new TestCaseData(nonWinningFields[2], WinOutcome.None),
                    new TestCaseData(nonWinningFields[3], WinOutcome.None),
                    new TestCaseData(nonWinningFields[4], WinOutcome.None),
                    new TestCaseData(nonWinningFields[5], WinOutcome.None),
                    new TestCaseData(nonWinningFields[6], WinOutcome.None),
                    new TestCaseData(nonWinningFields[7], WinOutcome.None),
                    new TestCaseData(nonWinningFields[8], WinOutcome.None),
                    new TestCaseData(nonWinningFields[9], WinOutcome.None),
                    new TestCaseData(nonWinningFields[10], WinOutcome.Draw),
                    new TestCaseData(nonWinningFields[11], WinOutcome.Draw),
                };
            }
        }

        public static List<TestCaseData> FieldsWithWinnersTestCases
        {
            get
            {
                InitializeCorrectFieldsWithWinners();
                return new List<TestCaseData>()
                {
                    new TestCaseData(fieldsWithWinners[0], WinOutcome.Cross),
                    new TestCaseData(fieldsWithWinners[1], WinOutcome.Circle),
                    new TestCaseData(fieldsWithWinners[2], WinOutcome.Cross),
                    new TestCaseData(fieldsWithWinners[3], WinOutcome.Circle),
                    new TestCaseData(fieldsWithWinners[4], WinOutcome.Cross),
                };
            }
        }

        public static List<TestCaseData> TwoWinnersFieldsTestCases
        {
            get
            {
                InitializeTwoWinnersFields();
                return new List<TestCaseData>()
                {
                    new TestCaseData(twoWinnersFields[0]),
                    new TestCaseData(twoWinnersFields[1]),
                };
            }
        }


        public static List<Field> fieldsWithWinners = Enumerable.Range(0, 5).Select(e => new Field()).ToList();

        public static List<Field> nonWinningFields = Enumerable.Range(0, 12).Select(e => new Field()).ToList();

        public static List<Field> twoWinnersFields = Enumerable.Range(0, 2).Select(e => new Field()).ToList();
        
        public static void InitializeCorrectNonWinnerFields()
        {
            //One Cross
            nonWinningFields[1][(0, 0)] = Element.Cross;

            //One Circle
            nonWinningFields[2][(0, 0)] = Element.Circle;

            //One Cross and Once Circle
            nonWinningFields[3][(0, 0)] = Element.Cross;
            nonWinningFields[3][(0, 1)] = Element.Circle;

            //One Cross and Two Circles
            nonWinningFields[4][(0, 0)] = Element.Cross;
            nonWinningFields[4][(0, 2)] = Element.Circle;
            nonWinningFields[4][(1, 2)] = Element.Circle;

            //Two Crosses and Two Circles
            nonWinningFields[5][(0, 0)] = Element.Cross;
            nonWinningFields[5][(2, 2)] = Element.Cross;
            nonWinningFields[5][(1, 1)] = Element.Circle;
            nonWinningFields[5][(1, 2)] = Element.Circle;

            //Three Non-winning Crosses and Two Circles
            //X X O
            //X O _
            //_ _ _
            nonWinningFields[6][(0, 0)] = Element.Cross;
            nonWinningFields[6][(0, 1)] = Element.Cross;
            nonWinningFields[6][(1, 0)] = Element.Cross;
            nonWinningFields[6][(0, 2)] = Element.Circle;
            nonWinningFields[6][(1, 1)] = Element.Circle;

            //Three Non-winning Circles and Two Crosses
            //_ O X
            //_ O _
            //X _ O
            nonWinningFields[7][(2, 2)] = Element.Circle;
            nonWinningFields[7][(1, 1)] = Element.Circle;
            nonWinningFields[7][(0, 1)] = Element.Circle;
            nonWinningFields[7][(0, 2)] = Element.Cross;
            nonWinningFields[7][(2, 0)] = Element.Cross;

            //Three Non-winning Crosses and Non-winning Circles
            //X O _
            //O X _
            //X O _
            nonWinningFields[8][(0, 0)] = Element.Cross;
            nonWinningFields[8][(1, 1)] = Element.Cross;
            nonWinningFields[8][(2, 0)] = Element.Cross;
            nonWinningFields[8][(0, 1)] = Element.Circle;
            nonWinningFields[8][(1, 0)] = Element.Circle;
            nonWinningFields[8][(2, 1)] = Element.Circle;

            //Four Non-winning Crosses and Non-winning Circles
            //X O X
            //X X O
            //O O _
            nonWinningFields[9][(0, 0)] = Element.Cross;
            nonWinningFields[9][(1, 0)] = Element.Cross;
            nonWinningFields[9][(1, 1)] = Element.Cross;
            nonWinningFields[9][(0, 2)] = Element.Cross;
            nonWinningFields[9][(2, 0)] = Element.Circle;
            nonWinningFields[9][(2, 1)] = Element.Circle;
            nonWinningFields[9][(1, 2)] = Element.Circle;
            nonWinningFields[9][(0, 1)] = Element.Circle;

            //Full Non-winning Field
            //X X O
            //O O X
            //X X O
            nonWinningFields[10][(0, 0)] = Element.Cross;
            nonWinningFields[10][(0, 1)] = Element.Cross;
            nonWinningFields[10][(1, 2)] = Element.Cross;
            nonWinningFields[10][(2, 0)] = Element.Cross;
            nonWinningFields[10][(2, 1)] = Element.Cross;
            nonWinningFields[10][(0, 2)] = Element.Circle;
            nonWinningFields[10][(1, 0)] = Element.Circle;
            nonWinningFields[10][(1, 1)] = Element.Circle;
            nonWinningFields[10][(2, 2)] = Element.Circle;

            //Full Non-winning Field
            //O X O
            //X X O
            //X O X
            nonWinningFields[11][(0, 1)] = Element.Cross;
            nonWinningFields[11][(1, 0)] = Element.Cross;
            nonWinningFields[11][(1, 1)] = Element.Cross;
            nonWinningFields[11][(2, 0)] = Element.Cross;
            nonWinningFields[11][(2, 2)] = Element.Cross;
            nonWinningFields[11][(0, 0)] = Element.Circle;
            nonWinningFields[11][(0, 2)] = Element.Circle;
            nonWinningFields[11][(1, 2)] = Element.Circle;
            nonWinningFields[11][(2, 1)] = Element.Circle;
        }

        public static void InitializeCorrectFieldsWithWinners()
        {
            //X X X
            //O O X
            //O O X
            fieldsWithWinners[0][(0, 0)] = Element.Cross;
            fieldsWithWinners[0][(0, 1)] = Element.Cross;
            fieldsWithWinners[0][(0, 2)] = Element.Cross;
            fieldsWithWinners[0][(1, 2)] = Element.Cross;
            fieldsWithWinners[0][(2, 2)] = Element.Cross;
            fieldsWithWinners[0][(1, 0)] = Element.Circle;
            fieldsWithWinners[0][(1, 1)] = Element.Circle;
            fieldsWithWinners[0][(2, 0)] = Element.Circle;
            fieldsWithWinners[0][(2, 1)] = Element.Circle;

            //O X O
            //X O X
            //O X O
            fieldsWithWinners[1][(0, 1)] = Element.Cross;
            fieldsWithWinners[1][(1, 0)] = Element.Cross;
            fieldsWithWinners[1][(1, 2)] = Element.Cross;
            fieldsWithWinners[1][(2, 1)] = Element.Cross;
            fieldsWithWinners[1][(0, 0)] = Element.Circle;
            fieldsWithWinners[1][(0, 2)] = Element.Circle;
            fieldsWithWinners[1][(1, 1)] = Element.Circle;
            fieldsWithWinners[1][(2, 0)] = Element.Circle;
            fieldsWithWinners[1][(2, 2)] = Element.Circle;

            //X X X
            //O _ O
            //_ _ _
            fieldsWithWinners[2][(0, 0)] = Element.Cross;
            fieldsWithWinners[2][(0, 1)] = Element.Cross;
            fieldsWithWinners[2][(0, 2)] = Element.Cross;
            fieldsWithWinners[2][(1, 0)] = Element.Circle;
            fieldsWithWinners[2][(1, 2)] = Element.Circle;

            //O X _
            //X O X
            //_ _ O
            fieldsWithWinners[3][(0, 1)] = Element.Cross;
            fieldsWithWinners[3][(1, 0)] = Element.Cross;
            fieldsWithWinners[3][(1, 2)] = Element.Circle;
            fieldsWithWinners[3][(0, 0)] = Element.Circle;
            fieldsWithWinners[3][(1, 1)] = Element.Circle;
            fieldsWithWinners[3][(2, 2)] = Element.Circle;

            //_ X O
            //_ X O
            //O X _
            fieldsWithWinners[4][(0, 1)] = Element.Cross;
            fieldsWithWinners[4][(1, 1)] = Element.Cross;
            fieldsWithWinners[4][(2, 1)] = Element.Cross;
            fieldsWithWinners[4][(0, 2)] = Element.Circle;
            fieldsWithWinners[4][(1, 2)] = Element.Circle;
            fieldsWithWinners[4][(2, 0)] = Element.Circle;
        }

        public static void InitializeTwoWinnersFields()
        {
            //X X X
            //O O O
            //_ _ _
            twoWinnersFields[0][(0, 0)] = Element.Cross;
            twoWinnersFields[0][(0, 1)] = Element.Cross;
            twoWinnersFields[0][(0, 2)] = Element.Cross;
            twoWinnersFields[0][(1, 0)] = Element.Circle;
            twoWinnersFields[0][(1, 1)] = Element.Circle;
            twoWinnersFields[0][(1, 2)] = Element.Circle;

            //X O X
            //X O O
            //X O X
            twoWinnersFields[1][(0, 0)] = Element.Cross;
            twoWinnersFields[1][(0, 2)] = Element.Cross;
            twoWinnersFields[1][(1, 0)] = Element.Cross;
            twoWinnersFields[1][(2, 0)] = Element.Cross;
            twoWinnersFields[1][(2, 2)] = Element.Cross;
            twoWinnersFields[1][(0, 1)] = Element.Circle;
            twoWinnersFields[1][(1, 1)] = Element.Circle;
            twoWinnersFields[1][(1, 2)] = Element.Circle;
            twoWinnersFields[1][(2, 1)] = Element.Circle;
        }


        [TestCaseSource(nameof(FieldsWithWinnersTestCases))]
        [TestCaseSource(nameof(NonWinningFieldsTestCases))]
        public void GetWinner_CorrectFields_CorrectResult(Field field, WinOutcome trueResult)
        {
            var result = FieldValidator.GetWinner(field);

            Assert.AreEqual(trueResult, result);
        }

        [TestCaseSource(nameof(TwoWinnersFieldsTestCases))]
        public void GetWinner_TwoWinnersFields_ThrowsFieldInvalidException(Field field)
        {
            Assert.Throws<FieldInvalidException>(() => FieldValidator.GetWinner(field));
        }
    }
}