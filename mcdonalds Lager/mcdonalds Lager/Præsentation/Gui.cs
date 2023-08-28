using mcdonalds_Lager.Præsentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager
{
    internal class Gui
    {
        /// <summary>
        /// Draw the view for the user 
        /// </summary>
        public static void DrawMainMenu()
        {
            ConsoleDraw.box box = new ConsoleDraw.box();
            box = ConsoleDraw.DrawBox(10, 10, 2, 2);
            ConsoleDraw.SplitBoxVertical(box, 5);
        }


    }
}
