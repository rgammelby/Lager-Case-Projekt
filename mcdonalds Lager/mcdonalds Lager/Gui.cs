using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager
{
    internal class Gui
    {
        private static void Draw<ItemToDraw>(ItemToDraw draw, int x, int y,ConsoleColor foreGroundColor)
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

        public static void DrawBox(int xSize, int ySize, int xStartPosition,int yStartPosition)
        {
            Draw('╔', xStartPosition, yStartPosition, ConsoleColor.White);
            DrawHorizontalLine(xSize, xStartPosition, yStartPosition);
            Draw('╗', xStartPosition + xSize, yStartPosition, ConsoleColor.White);

            DrawVerticalLine(ySize, xStartPosition, yStartPosition);
            DrawVerticalLine(ySize, xStartPosition + xSize, yStartPosition);

            Draw('╚', xStartPosition, yStartPosition + ySize, ConsoleColor.White);
            DrawHorizontalLine(xSize, xStartPosition, yStartPosition + ySize);
            Draw('╝', xStartPosition + xSize, yStartPosition + ySize, ConsoleColor.White);
        }

        
    }
}
