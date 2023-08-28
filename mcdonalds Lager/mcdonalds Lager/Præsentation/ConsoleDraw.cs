using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Præsentation
{
    internal class ConsoleDraw
    {
        private static void Draw<ItemToDraw>(ItemToDraw draw, int x, int y, ConsoleColor foreGroundColor)
        {
            Console.ForegroundColor = foreGroundColor;
            Console.SetCursorPosition(x, y);
            Console.Write(draw);
            Console.ResetColor();
        }

        private static void DrawVerticalLine(int length, int xStartPosition, int yStartPosition)
        {
            for (int i = 1; i < length; i++)
            {
                Draw('║', xStartPosition, yStartPosition + i, ConsoleColor.White);
            }
        }
        private static void DrawHorizontalLine(int length, int xStartPosition, int yStartPosition)
        {
            for (int i = 1; i < length; i++)
            {
                Draw('═', xStartPosition + i, yStartPosition, ConsoleColor.White);
            }
        }

        public class box
        {
            public int xSize;
            public int ySize;
            public int xStartPosition;
            public int yStartPosition;
            public List<int> ySplit = new List<int>();
        }
        /// <summary>
        /// Draw at box with the color white and return the box
        /// </summary>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        /// <param name="xStartPosition"></param>
        /// <param name="yStartPosition"></param>
        /// <returns></returns>
        public static box DrawBox(int xSize, int ySize, int xStartPosition, int yStartPosition)
        {
            box box = new box();
            box.xSize = xSize;
            box.ySize = ySize;
            box.xStartPosition = xStartPosition;
            box.yStartPosition = yStartPosition;
            box.ySplit.Add(xStartPosition);

            Draw('╔', xStartPosition, yStartPosition, ConsoleColor.White);
            DrawHorizontalLine(xSize, xStartPosition, yStartPosition);
            Draw('╗', xStartPosition + xSize, yStartPosition, ConsoleColor.White);

            DrawVerticalLine(ySize, xStartPosition, yStartPosition);
            DrawVerticalLine(ySize, xStartPosition + xSize, yStartPosition);

            Draw('╚', xStartPosition, yStartPosition + ySize, ConsoleColor.White);
            DrawHorizontalLine(xSize, xStartPosition, yStartPosition + ySize);
            Draw('╝', xStartPosition + xSize, yStartPosition + ySize, ConsoleColor.White);

            return box;
        }
        public static box SplitBoxVertical(box box, int splitAt)
        {
            box.ySplit.Add(box.xStartPosition + splitAt);
            Draw('╦', box.xStartPosition + splitAt, box.yStartPosition, ConsoleColor.White);
            DrawVerticalLine(box.ySize, box.ySplit.Last(), box.yStartPosition);
            Draw('╩', box.xStartPosition + splitAt, box.yStartPosition + box.ySize, ConsoleColor.White);
            return box;
        }
    }
}
