using mcdonalds_Lager.Præsentation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager
{
    public class MainMenu
    {
        const int Y_WIREFRAME_SIZE = 2;
        const int X_WIREFRAME_START_LOCATION = 2;
        /// <summary>
        /// Draw alle the none database need menus
        /// The input is from the class UserController
        /// </summary>
        public static box DrawMenu(string[] titel, int startPositionY)
        {
            box box = DrawWireFrameBox(titel, startPositionY);

            AddSplitToMenu(titel, box);
            AddtitelToMenu(titel, box);
            
            ConsoleDraw.Draw(titel[0], box.ySplit[0] + 1, box.yStartPosition + 1, ConsoleColor.DarkRed);
            return box;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="titel"></param>
        /// <returns></returns>
        private static box DrawWireFrameBox(string[] titel, int startPositionY)
        {
            box box = new box();
            //Makes the box and gets the size from the length of the titel
            int sum = 0;
            foreach (string item in titel)
            {
                sum += item.Length + 2;
            }
            box = ConsoleDraw.DrawBox(sum, Y_WIREFRAME_SIZE, X_WIREFRAME_START_LOCATION, startPositionY);

            
            return box;
        }
        private static void AddSplitToMenu(string[] titel, box box)
        {
            int sum = 0;
            //splits up the box
            for (int i = 0; i < titel.Length - 1; i++)
            {
                ConsoleDraw.SplitBoxVertical(box, titel[i].Length + sum + 2);
                sum += titel[i].Length + 2;
            }
        }
        private static void AddtitelToMenu(string[] titel, box box)
        {
            //Prints the titils in the WireFrame box 
            for (int i = 0; i < titel.Length; i++)
            {
                ConsoleDraw.Draw(titel[i], box.ySplit[i] + 1, box.yStartPosition + 1, ConsoleColor.White);
            }
        }

    }
}
