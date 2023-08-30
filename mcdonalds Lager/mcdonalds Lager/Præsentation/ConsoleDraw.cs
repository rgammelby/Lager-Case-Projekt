using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Præsentation
{
    public class box
    {
        public int xSize;
        public int ySize;
        public int xStartPosition;
        public int yStartPosition;
        public List<int> ySplit = new List<int>();
        public List<int> xSplit = new List<int>();
    }
    internal class ConsoleDraw
    {
        /// <summary>
        /// Can draw input at a chosen potion on the console with a chosen foreGruondColor
        /// </summary>
        /// <typeparam name="ItemToDraw"></typeparam>
        /// <param name="draw"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="foreGroundColor"></param>
        public static void Draw<ItemToDraw>(ItemToDraw draw, int x, int y, ConsoleColor foreGroundColor)
        {
            Console.ForegroundColor = foreGroundColor;
            Console.SetCursorPosition(x, y);
            Console.Write(draw);
            Console.ResetColor();
        }

        #region LinesMethods
        /// <summary>
        /// Makes a line from bottom to top by the parameters
        /// </summary>
        /// <param name="length"></param>
        /// <param name="xStartPosition"></param>
        /// <param name="yStartPosition"></param>
        private static void DrawVerticalLine(int length, int xStartPosition, int yStartPosition)
        {
            for (int i = 1; i < length; i++)
            {
                Draw('║', xStartPosition, yStartPosition + i, ConsoleColor.White);
            }
        }
        /// <summary>
        /// Makes a line from left to right by the parameters
        /// </summary>
        /// <param name="length"></param>
        /// <param name="xStartPosition"></param>
        /// <param name="yStartPosition"></param>
        private static void DrawHorizontalLine(int length, int xStartPosition, int yStartPosition)
        {
            for (int i = 1; i < length; i++)
            {
                Draw('═', xStartPosition + i, yStartPosition, ConsoleColor.White);
            }
        }
        #endregion
        /// <summary>
        /// Draws the overlaping lines in the box
        /// </summary>
        /// <param name="box"></param>
        private static void DrawOverlapingLine(box box)
        {
            for (int i = 0; i < box.xSplit.Count(); i++)
            {
                for (int j = 1; j < box.ySplit.Count(); j++)
                {
                    Draw('╬', box.ySplit[j], box.xSplit[i], ConsoleColor.White);
                }
            }
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
            //Top line
            Draw('╔', xStartPosition, yStartPosition, ConsoleColor.White);
            DrawHorizontalLine(xSize, xStartPosition, yStartPosition);
            Draw('╗', xStartPosition + xSize, yStartPosition, ConsoleColor.White);
            //Side lines
            DrawVerticalLine(ySize, xStartPosition, yStartPosition);
            DrawVerticalLine(ySize, xStartPosition + xSize, yStartPosition);
            //bottom line
            Draw('╚', xStartPosition, yStartPosition + ySize, ConsoleColor.White);
            DrawHorizontalLine(xSize, xStartPosition, yStartPosition + ySize);
            Draw('╝', xStartPosition + xSize, yStartPosition + ySize, ConsoleColor.White);

            return box;
        }
        #region SplitMethods
        /// <summary>
        /// Split the box up on the Vertical and save the postion 
        /// </summary>
        /// <param name="box"></param>
        /// <param name="splitAt"></param>
        /// <returns></returns>
        public static box SplitBoxVertical(box box, int splitAt)
        {
            box.ySplit.Add(box.xStartPosition + splitAt);
            Draw('╦', box.xStartPosition + splitAt, box.yStartPosition, ConsoleColor.White);
            DrawVerticalLine(box.ySize, box.ySplit.Last(), box.yStartPosition);
            Draw('╩', box.xStartPosition + splitAt, box.yStartPosition + box.ySize, ConsoleColor.White);
            return box;
        }
        public static box SplitBoxHorizontal(box box, int splitAt)
        {
            box.xSplit.Add(box.yStartPosition + splitAt);
            Draw('╠', box.xStartPosition, box.yStartPosition + splitAt, ConsoleColor.White);
            DrawHorizontalLine(box.xSize, box.xStartPosition, box.yStartPosition + splitAt);
            Draw('╣', box.xStartPosition + box.xSize, box.yStartPosition + splitAt, ConsoleColor.White);
            //Draws the overlap chars
            DrawOverlapingLine(box);
            return box;
        }
        #endregion
    }
}
