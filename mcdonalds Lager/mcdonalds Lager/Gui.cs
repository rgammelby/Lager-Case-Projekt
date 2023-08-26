using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager
{
    internal class Gui
    {
        private static void Draw<ItemToDraw>(ItemToDraw Draw, int x, int y,ConsoleColor foreGroundColor)
        {
            Console.ForegroundColor = foreGroundColor;
            Console.SetCursorPosition(x, y);
            Console.Write(Draw);
            Console.ResetColor();
        }


        public static void DrawBox(int xSize, int ySize, int xStartPosition,int yStartPosition)
        {

        }
    }
}
