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
        static string[] mainMenuTitels = { "Ingredients", "Orders", "Drinks" };
        static string[] DrinksMenuTitels = { "Water", "juice", "soda", "frappe","milkshake","coffe", "alcohol" };
        /// <summary>
        /// Draw the first view for the user 
        /// </summary>
        public static void DrawMainMenu()
        {
            ConsoleDraw.box box = DrawWireFrameBox(mainMenuTitels);              
        }
        public static void DrawDrinksMenu()
        {
            ConsoleDraw.box box = DrawWireFrameBox(DrinksMenuTitels);
        }

        private static ConsoleDraw.box DrawWireFrameBox(string[] titel)
        {
            ConsoleDraw.box box = new ConsoleDraw.box();
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
