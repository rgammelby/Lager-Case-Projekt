using mcdonalds_Lager.Præsentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager
{
    public class Gui
    {
        static string[] titels = { "Ingredients", "Orders", "Drinks" };
        /// <summary>
        /// Draw the first view for the user 
        /// </summary>
        public static void DrawMainMenu()
        {            
            ConsoleDraw.box box = new ConsoleDraw.box();
            ConsoleDraw.DrawBox(60, 5, 2, 1);
            box = ConsoleDraw.DrawBox(45, 2, 3, 2);
            for (int i = 1; i < 3; i++)
            {          
                ConsoleDraw.SplitBoxVertical(box, 15 * i);
            }
            
            for (int i = 0; i < titels.Length; i++)
            {
                ConsoleDraw.Draw(titels[i], box.ySplit[i] + 1,box.yStartPosition + 1, ConsoleColor.White);
            }
            
        }


    }
}
