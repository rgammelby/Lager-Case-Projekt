using mcdonalds_Lager.Præsentation;
using System;
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
        static string tabel;
        /// <summary>
        /// 
        /// </summary>
        public static void Controller()
        {
            titel = mainMenuTitels;
            box box = Gui.DrawMenu(titel);

            int x = 0;
            while (true)
            {
                if (titel == mainMenuTitels || titel == drinksMenuTitels || titel == ingredientsTitels)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (x > 0)
                            {
                                ConsoleDraw.Draw(titel[x], box.ySplit[x] + 1, box.ySize + 1, ConsoleColor.White);
                                x--;
                                ConsoleDraw.Draw(titel[x], box.ySplit[x] + 1, box.ySize + 1, ConsoleColor.DarkRed);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (x < box.ySplit.Count - 1)
                            {
                                ConsoleDraw.Draw(titel[x], box.ySplit[x] + 1, box.ySize + 1, ConsoleColor.White);
                                x++;
                                ConsoleDraw.Draw(titel[x], box.ySplit[x] + 1, box.ySize + 1, ConsoleColor.DarkRed);
                            }
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            box = NewMenuController(box, x);
                            
                            x = 0;
                            break;
                        default:
                            break;
                    }
                }               
            }
        }
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
                switch (x)
                {
                    case 0:
                        tabel = "Water";
                        box = Gui.DrawBuyMenu(titel);
                        break;
                    case 1:
                        tabel = "juice";
                        box = Gui.DrawBuyMenu(titel);
                        break;
                    case 2:
                        tabel = "soda";
                        box = Gui.DrawBuyMenu(titel);
                        break;
                    case 3:
                        tabel = "frappe";
                        box = Gui.DrawBuyMenu(titel);
                        break;
                    case 4:
                        tabel = "milkshake";
                        box = Gui.DrawBuyMenu(titel);
                        break;
                    case 5:
                        tabel = "coffee";
                        box = Gui.DrawBuyMenu(titel);
                        break;
                    case 6:
                        tabel = "alcohol";
                        titel = new string[] { "Buy", "Name", "Litres" };
                        box = Gui.DrawBuyMenu(titel);
                        break;
                }
            }

            if (titel == ingredientsTitels)
            {

            }



                    return box;
        }
    }
}
