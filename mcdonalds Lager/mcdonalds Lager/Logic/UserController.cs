using mcdonalds_Lager.Præsentation;
using System;

namespace mcdonalds_Lager.Logic
{

    internal class UserController
    {
        static string[] mainMenuTitels = { "Ingredients", "Orders", "Drinks" };
        static string[] drinksMenuTitels = { "Water", "Juice", "Soda", "Frappe", "Milkshake", "Coffe", "Alcohol" };
        static string[] ingredientsTitels = { "Meat", "Cheese", "Bread", "Dressing And Dip", "Salad", "Fruits" };
        static string[] titel;
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
                    default:
                        break;
                }
            }
            if (titel == drinksMenuTitels)
            {
                switch (x)
                {
                    case 0:
                        titel = new string[] {"Buy","Brand","Amount"};
                        box = Gui.DrawMenu(titel);
                        break;
                    case 1:
                        box = Gui.DrawMenu(mainMenuTitels);
                        break;
                    case 2:
                        titel = drinksMenuTitels;
                        box = Gui.DrawMenu(drinksMenuTitels);

                        break;
                    default:
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
