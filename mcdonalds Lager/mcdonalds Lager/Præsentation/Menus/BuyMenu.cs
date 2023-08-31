using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Præsentation
{
    internal class BuyMenu
    {
        const int X_BUY_MENU_SIZE = 30;
        const int Y_BUY_MENU_SIZE = 2;
        // draws input field at console position x, y
        public static void InputField(int x, int y)
        {
            ConsoleDraw.DrawBox(X_BUY_MENU_SIZE, Y_BUY_MENU_SIZE, x, y);
            Console.SetCursorPosition(x + 1, y + 1);
        }
    }
    
}
