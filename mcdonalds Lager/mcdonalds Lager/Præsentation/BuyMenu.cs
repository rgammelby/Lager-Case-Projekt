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
        public static box DrawBuyMenu(DataTable dt)
        {
            List<string> titel = new List<string> { "Buy" };
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                titel.Add(dt.Columns[i].ToString());
            }

            box box = ConsoleDraw.DrawBox(20 * (titel.Count - 1) + 5, 22, 3, 2);


            ConsoleDraw.SplitBoxVertical(box, 5);
            for (int i = 1; i < titel.Count - 1; i++)
            {
                ConsoleDraw.SplitBoxVertical(box, 20 * i);
            }
            //Prints the titils in the box 
            for (int i = 0; i < titel.Count; i++)
            {
                ConsoleDraw.Draw(titel[i], box.ySplit[i] + 1, box.yStartPosition + 1, ConsoleColor.White);
            }
            //Draw the buy text on the left
            for (int i = 0; i < 10; i++)
            {
                ConsoleDraw.SplitBoxHorizontal(box, (i * 2) + 2);
                ConsoleDraw.Draw(titel[0], box.xSplit[0], box.xSplit[i] + 1, ConsoleColor.White);
            }

            DrawDataToBox(dt, box);

            //Makes the first buy red
            ConsoleDraw.Draw(titel[0], box.xSplit[0], box.xSplit[0] + 1, ConsoleColor.DarkRed);

            return box;
        }
        private static void DrawDataToBox(DataTable dt,box box)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int n = 1; n < dt.Rows[i].ItemArray.Length; n++)
                {
                    ConsoleDraw.Draw(dt.Rows[i].ItemArray[n], box.ySplit[n] + 1, box.xSplit[i] + 1, ConsoleColor.White);
                }
            }
        }
    }
    
}
