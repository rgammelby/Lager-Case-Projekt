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
        static int cursorLoction = 0;
        /// <summary>
        /// 
        /// </summary>
        #region GuiControllers
        private static void BuyController(box box)
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursorLoction > 0)
                        {
                            BuyControllerMover(-1, box);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorLoction < box.xSplit.Count - 1)
                        {
                            BuyControllerMover(1,box);
                        }
                        break;
                    case ConsoleKey.Enter:
                        cursorLoction = 0;
                        Console.Clear();
                        box = MenuTitelAndTableController(box, cursorLoction);
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
        /// <summary>
        /// Moves the red titel and makes the old white 
        /// </summary>
        /// <param name="moved"></param>
        /// <param name="box"></param>
        private static void BuyControllerMover(int moved, box box)
        {
            ConsoleDraw.Draw("buy", box.ySplit[0] + 1, box.xSplit[cursorLoction] + 1, ConsoleColor.White);
            cursorLoction += moved;
            ConsoleDraw.Draw("buy", box.ySplit[0] + 1, box.xSplit[cursorLoction] + 1, ConsoleColor.DarkRed);
        }

        public static void MainController()
        {
            cursorLoction = 0;
            titel = mainMenuTitels;
            box box = Gui.DrawMenu(titel);
            while (true)
            {
                if (titel == mainMenuTitels || titel == drinksMenuTitels || titel == ingredientsTitels)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (cursorLoction > 0)
                            {
                                MainControllerMover(-1, box);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (cursorLoction < box.ySplit.Count - 1)
                            {
                                MainControllerMover(1,box);
                            }
                            break;
                        case ConsoleKey.Enter:
                            cursorLoction = 0;
                            Console.Clear();
                            //Controlle for if you are in the last view for bofore the buy Gui/view
                            if (titel == drinksMenuTitels || titel == ingredientsTitels)
                            {
                                BuyController(box);
                            }
                            else
                            {
                                //Gets the new menu
                                box = MenuTitelAndTableController(box, cursorLoction);
                            }                           
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Moves the red titel and makes the old white 
        /// </summary>
        /// <param name="moved"></param>
        /// <param name="box"></param>
        private static void MainControllerMover(int moved, box box)
        {
            ConsoleDraw.Draw(titel[cursorLoction], box.ySplit[cursorLoction] + 1, box.ySize + 1, ConsoleColor.White);
            cursorLoction += moved;
            ConsoleDraw.Draw(titel[cursorLoction], box.ySplit[cursorLoction] + 1, box.ySize + 1, ConsoleColor.DarkRed);
        }

        #endregion
        private static box MenuTitelAndTableController(box box,int x)
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
                    //If there is no problem in the code will this never run
                    default:
                        Console.Clear();
                        Console.WriteLine("Error");
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;
                }
            }

            else if (titel == drinksMenuTitels)
            {
                //Table Names do not remove
                string[] tableList = { "Water", "juice", "soda", "frappe", "milkshake", "coffee", "alcohol" };
                titel = new string[0];
                box = BuyMenu.DrawBuyMenu(Getdata.GetDatabaseItems(tableList[x]));
            }

            else if (titel == ingredientsTitels)
            {
                //Table Names do not remove
                string[] tableList = { "meat", "cheese", "bread", "dad", "salad", "fav" };
                titel = new string[0];
                box = BuyMenu.DrawBuyMenu(Getdata.GetDatabaseItems(tableList[x]));
            }

            return box;
        }


    }

}
