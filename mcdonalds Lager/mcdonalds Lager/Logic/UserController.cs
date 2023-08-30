using mcdonalds_Lager.Præsentation;
using mcdonalds_Lager.Præsentation.Menus;
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
        static string table;
        static int cursorLoction = 0;
        /// <summary>
        /// 
        /// </summary>
        #region GuiControllers

        private static void OrderController()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Backspace:
                        MainController();
                        break;
                }
            }
        }
        private static void TableController(box box)
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
                        
                        Buy.Input();
                        // table cursorLoction + 1
                        MainController();
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
            Console.Clear();
            cursorLoction = 0;
            titel = mainMenuTitels;
            box box = MainMenu.DrawMenu(titel);
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
                            
                            Console.Clear();

                            //Controlle for if you are in the last view for bofore the buy Gui/view
                            if (titel == drinksMenuTitels || titel == ingredientsTitels)
                            {
                                box = MenuTitelAndTableController(box, cursorLoction);
                                cursorLoction = 0;
                                TableController(box);
                            }
                            //Gets the new menu
                            box = MenuTitelAndTableController(box, cursorLoction);
                            cursorLoction = 0;
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
                        box = MainMenu.DrawMenu(ingredientsTitels);
                        break;
                    case 1:
                        OrderMenu.DrawOrderMenu();
                        OrderController();
                        break;
                    case 2:
                        titel = drinksMenuTitels;
                        box = MainMenu.DrawMenu(drinksMenuTitels);
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
                table = tableList[x];
                box = TableMenu.DrawTableMenu(LogicData.GetDatabaseItems(table));
            }

            else if (titel == ingredientsTitels)
            {
                //Table Names do not remove
                string[] tableList = { "meat", "cheese", "bread", "Dressing_And_Dip", "salad", "Fruit_And_Veg" };
                titel = new string[0];
                table = tableList[x];
                box = TableMenu.DrawTableMenu(LogicData.GetDatabaseItems(table));
            }
            return box;
        }


    }

}
