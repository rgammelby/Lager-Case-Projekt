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
        // draws input field at console position x, y
        public static void InputField(int x, int y)
        {
            ConsoleDraw.DrawBox(30, 2, x, y);
            Console.SetCursorPosition(x + 1, y + 1);
        }
    }
    
}
