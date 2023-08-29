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

        /// <summary>
        /// Draw the first view for the user 
        /// </summary>
        public static box DrawMenu(string[] titel)
        {
            box box = DrawWireFrameBox(titel);
            ConsoleDraw.Draw(titel[0], box.ySplit[0] + 1, box.ySize + 1, ConsoleColor.DarkRed);
            return box;
        }
        public static box DrawBuyMenu(string[] titel)
        {
            box box = ConsoleDraw.DrawBox(20 * (titel.Length - 1) + 5, 22, 3, 2);

            ConsoleDraw.SplitBoxVertical(box, 5);
            for (int i = 1; i < titel.Length - 1; i++)
            {
                ConsoleDraw.SplitBoxVertical(box, 20 * i);
            }
            //Prints the titils in the box 
            for (int i = 0; i < titel.Length; i++)
            {
                ConsoleDraw.Draw(titel[i], box.ySplit[i] + 1, box.yStartPosition + 1, ConsoleColor.White);
            }
            //Draw the buy text on the left
            for (int i = 0;i < 10; i++)
            {
                ConsoleDraw.SplitBoxHorizontal(box, (i * 2) + 2);
                ConsoleDraw.Draw(titel[0], box.xSplit[0], box.xSplit[i] + 1, ConsoleColor.White);
            }

            for (int i = 0; i < length; i++)
            {

            }

            //Makes the first buy red
            ConsoleDraw.Draw(titel[0], box.xSplit[0], box.xSplit[0] + 1, ConsoleColor.DarkRed);

            return box;
        }

        private static box DrawWireFrameBox(string[] titel)
        {
            box box = new box();
            //Makes the box and gets the size from the length of the titel
            int sum = 0;
            foreach (string item in titel)
            {
                sum += item.Length + 2;
            }
            box = ConsoleDraw.DrawBox(sum, 2, 3, 2);
            sum = 0;
            //splits up the box
            for (int i = 0; i < titel.Length - 1; i++)
            {
                ConsoleDraw.SplitBoxVertical(box, titel[i].Length + sum + 2);
                sum += titel[i].Length + 2;
            }
            //Prints the titils in the box 
            for (int i = 0; i < titel.Length; i++)
            {
                ConsoleDraw.Draw(titel[i], box.ySplit[i] + 1, box.yStartPosition + 1, ConsoleColor.White);
            }
            return box;
        }

    }
}
