using mcdonalds_Lager.Præsentation;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Reflection.Emit;

namespace mcdonalds_Lager.Logic
{

    internal class UserController
    {
        static string[] mainMenuTitels = { "Ingredients", "Orders", "Drinks" };
        static string[] drinksMenuTitels = { "Water", "Juice", "Soda", "Frappe", "Milkshake", "Coffe", "Alcohol" };
        static string[] ingredientsTitels = { "Meat", "Cheese", "Bread", "Dressing And Dip", "Salad", "Fruits" };
        static string[] titel;

        /// <summary>
        /// 
        /// </summary>
        #region GuiControllers
        private static void BuyController(box box)
        {
            int cursorLoction = 0;
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursorLoction > 0)
                        {
                            ConsoleDraw.Draw("buy", box.ySplit[0] + 1, box.xSplit[cursorLoction] + 1, ConsoleColor.White);
                            cursorLoction--;
                            ConsoleDraw.Draw("buy", box.ySplit[0] + 1, box.xSplit[cursorLoction] + 1, ConsoleColor.DarkRed);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorLoction < box.xSplit.Count - 1)
                        {
                            ConsoleDraw.Draw("buy", box.ySplit[0] + 1, box.xSplit[cursorLoction] + 1, ConsoleColor.White);
                            cursorLoction++;
                            ConsoleDraw.Draw("buy", box.ySplit[0] + 1, box.xSplit[cursorLoction] + 1, ConsoleColor.DarkRed);
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        box = NewMenuController(box, cursorLoction);
                        cursorLoction = 0;
                        break;
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        MainController();
                        break;
                    default:
                        break;
                }
            }
        }
        public static void MainController()
        {
            titel = mainMenuTitels;
            box box = Gui.DrawMenu(titel);
            int cursorLoction = 0;
            while (true)
            {
                if (titel == mainMenuTitels || titel == drinksMenuTitels || titel == ingredientsTitels)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (cursorLoction > 0)
                            {
                                ConsoleDraw.Draw(titel[cursorLoction], box.ySplit[cursorLoction] + 1, box.ySize + 1, ConsoleColor.White);
                                cursorLoction--;
                                ConsoleDraw.Draw(titel[cursorLoction], box.ySplit[cursorLoction] + 1, box.ySize + 1, ConsoleColor.DarkRed);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (cursorLoction < box.ySplit.Count - 1)
                            {
                                ConsoleDraw.Draw(titel[cursorLoction], box.ySplit[cursorLoction] + 1, box.ySize + 1, ConsoleColor.White);
                                cursorLoction++;
                                ConsoleDraw.Draw(titel[cursorLoction], box.ySplit[cursorLoction] + 1, box.ySize + 1, ConsoleColor.DarkRed);
                            }
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            box = NewMenuController(box, cursorLoction);
                            //Controlle for if you are in the last view for bofore the buy Gui/view
                            if (titel != drinksMenuTitels && titel != ingredientsTitels)
                            {
                                BuyController(box);
                            }                               
                            cursorLoction = 0;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion
        private static box NewMenuController(box box,int x)
        {
            if (titel == mainMenuTitels)
            {
                switch (x)
                {
                    case 0:
                        titel = ingredientsTitels;
                        box = Gui.DrawMenu(ingredientsTitels);
                        break;
                    case 1:
                        box = Gui.DrawMenu(mainMenuTitels);
                        break;
                    case 2:
                        titel = drinksMenuTitels;
                        box = Gui.DrawMenu(drinksMenuTitels);
                        break;
                }
            }

            else if (titel == drinksMenuTitels)
            {
                //Table Names do not remove
                string[] tableList = { "Water", "juice", "soda", "frappe", "milkshake", "coffee", "alcohol" };
                titel = new string[0];
                box = Gui.DrawBuyMenu(GetDatabaseItems(tableList[x]));
            }

            else if (titel == ingredientsTitels)
            {
                //Table Names do not remove
                string[] tableList = { "meat", "cheese", "bread", "dad", "salad", "fav" };
                titel = new string[0];
                box = Gui.DrawBuyMenu(GetDatabaseItems(tableList[x]));
            }

            return box;
        }
        /// <summary>
        /// Gets the dataTable from the database from the "table"
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static DataTable GetDatabaseItems(string table)
        {
            var dt = DataAccessLayer.GetData($"SELECT * FROM {table}");
            return dt;
        }
    }

}
