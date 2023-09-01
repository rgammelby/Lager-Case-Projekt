using mcdonalds_Lager.Dal;
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
        static string[] drinksMenuTitels = { "Water", "Juice", "Soda", "Frappe", "Milkshake", "Coffee", "Alcohol" };
        static string[] ingredientsTitels = { "Meat", "Cheese", "Bread", "Dressing And Dip", "Salad", "Fruits" };
        static string[] titel;
        static string table;
        static int yCursorLoction = 0; 
        static int xCursorLoction = 0;

        #region GuiControllers
        /// <summary>
        /// Controlls the user input on the order page 
        /// The user can only go back to main menu in order
        /// </summary>
        private static void OrderController()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        MainAndTableController();
                        break;
                }
            }
        }
        /// <summary>
        /// Controlls movement from the users input
        /// </summary>
        public static void MainAndTableController()
        {
            Console.Clear();
            xCursorLoction = 0;
            titel = mainMenuTitels;
            box box = MainMenu.DrawMenu(titel, 2);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (yCursorLoction > 0 && titel != mainMenuTitels && titel != drinksMenuTitels && titel != ingredientsTitels)
                        {
                            ControlleMover(-1, box,true);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (yCursorLoction < box.xSplit.Count - 1 && titel != mainMenuTitels && titel != drinksMenuTitels && titel != ingredientsTitels) 
                        {
                            ControlleMover(1,box, true);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (xCursorLoction > 0)
                        {
                            ControlleMover(-1, box, false);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (titel != mainMenuTitels && titel != drinksMenuTitels && titel != ingredientsTitels)
                        {
                            if (xCursorLoction < 1)
                            {
                                ControlleMover(1, box, false);
                            }
                            break;
                        }
                        //used for the table menus
                        if (xCursorLoction < box.ySplit.Count - 1)
                        {
                            ControlleMover(1, box, false);
                        }
                        break;
                    case ConsoleKey.Enter:

                        if (titel == mainMenuTitels)
                        {
                            box = MenuTitelAndTableController(box, xCursorLoction);
                        }

                        else if (titel == drinksMenuTitels || titel == ingredientsTitels)
                        {
                            Console.Clear();
                            box = MenuTitelAndTableController(box, xCursorLoction);
                        }
                        else
                        //Buy or take buttons
                        {
                            //buy
                            if (xCursorLoction == 0)
                            {
                                if (Update.UpdateData(table, yCursorLoction + 1, Buy.Input(), true) == false)
                                {
                                    LogicData.WithdrawError();
                                }
                            }
                            //take
                            else
                            {
                                if (Update.UpdateData(table, yCursorLoction + 1, Buy.Input(), false) == false)
                                {
                                    LogicData.WithdrawError();
                                }
                            }
                            MainAndTableController();
                        }



                        yCursorLoction = 0;
                        xCursorLoction = 0;
                        break;
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        MainAndTableController();
                        break;
                    default:
                        break;
                }
            }
        }
        #region MoversForControllers
        /// <summary>
        /// Moves the red titel and makes the old white 
        /// </summary>
        /// <param name="moved"></param>
        /// <param name="box"></param>
        private static void ControlleMover(int moved, box box,bool side)
        {
            
            if (titel == mainMenuTitels || titel == drinksMenuTitels || titel == ingredientsTitels)
            {
                MainControllerMover(moved, box);
                    return;
            }
            TableControllerMover(moved, box, side);
        }

        private static void TableControllerMover(int moved, box box, bool side)
        {
            string[] strings = { "Buy", "Take" };
            if (box.xSplit.Count > 0)
            {
                ConsoleDraw.Draw(strings[xCursorLoction], box.ySplit[xCursorLoction] + 1, box.xSplit[yCursorLoction] + 1, ConsoleColor.White);
                if (side)
                {
                    yCursorLoction += moved;
                }
                else
                {
                    xCursorLoction += moved;
                }
                ConsoleDraw.Draw(strings[xCursorLoction], box.ySplit[xCursorLoction] + 1, box.xSplit[yCursorLoction] + 1, ConsoleColor.DarkRed);
            }

        }
        /// <summary>
        /// Moves the red titel and makes the old white 
        /// </summary>
        /// <param name="moved"></param>
        /// <param name="box"></param>

        private static void MainControllerMover(int moved, box box)
        {
            ConsoleDraw.Draw(titel[xCursorLoction], box.ySplit[xCursorLoction] + 1, box.yStartPosition + 1, ConsoleColor.White);
            xCursorLoction += moved;
            ConsoleDraw.Draw(titel[xCursorLoction], box.ySplit[xCursorLoction] + 1, box.yStartPosition + 1, ConsoleColor.DarkRed);
        }
        #endregion
        #endregion
        private static box MenuTitelAndTableController(box box,int x)
        {
            if (titel == mainMenuTitels)
            {
                switch (x)
                {
                    case 0:
                        titel = ingredientsTitels;
                        box = MainMenu.DrawMenu(ingredientsTitels, 5);
                        break;
                    case 1:
                        OrderMenu.DrawOrderMenu();
                        OrderController();
                        break;
                    case 2:
                        titel = drinksMenuTitels;
                        box = MainMenu.DrawMenu(drinksMenuTitels, 5);
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
