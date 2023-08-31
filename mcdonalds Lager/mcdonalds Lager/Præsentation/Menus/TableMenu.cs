using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Præsentation
{
    internal class TableMenu
    {
        public static box DrawTableMenu(DataTable dt)
        {
            List<string> titel = new List<string> { "Buy","Take" };
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                titel.Add(dt.Columns[i].ToString());
            }

            box box = ConsoleDraw.DrawBox(20 * (titel.Count - 1) + 5, (dt.Rows.Count * 2) + 2, 3, 2);

            DrawVerticalSplitOnTableMenu(titel, box);

            DrawTitelsOnTableMenu(titel, box);

            DrawBuyTextToTableMenu(dt,titel,box);

            DrawDataToTableMenu(dt, box);


            return box;
        }

        #region
        private static void DrawVerticalSplitOnTableMenu(List<string> titel,box box)
        {
            //Makes the split for the buy text
            for (int i = 1; i <= 2; i++)
            {
                ConsoleDraw.SplitBoxVertical(box, (5 * i) + i);
            }
           
            //Split up the box for the data
            for (int i = 2; i < titel.Count - 1; i++)
            {
                ConsoleDraw.SplitBoxVertical(box, 20 * i);
            }
        }
        private static void DrawTitelsOnTableMenu(List<string> titel, box box)
        {
            //Prints the titles in the box 
            for (int i = 0; i < titel.Count; i++)
            {
                ConsoleDraw.Draw(titel[i], box.ySplit[i] + 1, box.yStartPosition + 1, ConsoleColor.White);
            }
        }
        private static void DrawBuyTextToTableMenu(DataTable dt,List<string> titel, box box)
        {
            if(dt.Rows.Count > 0)
            {
                //Draw the buy text on the left
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ConsoleDraw.SplitBoxHorizontal(box, (i * 2) + 2);
                    ConsoleDraw.Draw(titel[0], box.ySplit[0] + 1, box.xSplit[0 + i] + 1, ConsoleColor.White);
                    ConsoleDraw.Draw(titel[1], box.ySplit[1] + 1, box.xSplit[0 + i] + 1, ConsoleColor.White);
                }

                //Makes the first buy red
                ConsoleDraw.Draw(titel[0], box.xSplit[0], box.xSplit[0] + 1, ConsoleColor.DarkRed);
            }
            else
            {
                ConsoleDraw.Draw("Ingen data :-(", box.xStartPosition, box.yStartPosition + 3, ConsoleColor.White);
            }
        }
        private static void DrawDataToTableMenu(DataTable dt, box box)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int n = 1; n < dt.Rows[i].ItemArray.Length; n++)
                {
                    ConsoleDraw.Draw(dt.Rows[i].ItemArray[n], box.ySplit[n + 1] + 1, box.xSplit[i] + 1, ConsoleColor.White);
                }
            }
        }
        #endregion
    }
}