using TicTacToeGame.Enums;

namespace TicTacToeGame.FieldHelpers
{
    public static class FieldRenderer
    {
        private const string CROSS_RENDER = "X";
        private const string CIRCLE_RENDER = "O";
        private const string NONE_RENDER = " ";
        private const string CELL_SEPARATOR = "|";

        private static Dictionary<Element, string> ElementVisualizations = new Dictionary<Element, string>()
        {
            [Element.None] = NONE_RENDER,
            [Element.Circle] = CIRCLE_RENDER,
            [Element.Cross] = CROSS_RENDER
        };

        /// <summary>
        /// Renders a passed square field by rows separated by newlines.
        /// </summary>
        /// <param name="field">Field to render.</param>
        public static void RenderField(Field field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            int fieldSize = field.Size;

            for (int i = 0; i < fieldSize; i++)
            {
                RenderFieldRow(field, i);
            }
        }

        /// <summary>
        /// Writes to Console visual representations of Elements separated by a separator. A row ends with a newline.
        /// </summary>
        /// <param name="field">Field whose row has to be rendered</param>
        /// <param name="rowIndex">Index of the rendering row</param>
        private static void RenderFieldRow(Field field, int rowIndex)
        {
            int fieldSize = field.Size;

            Console.Write(CELL_SEPARATOR);

            for (int j = 0; j < fieldSize; j++)
            {
                Element elementToRender = field[(rowIndex, j)];
                Console.Write(ElementVisualizations[elementToRender]);
                Console.Write(CELL_SEPARATOR);
            }

            Console.WriteLine();
        }
    }
}
