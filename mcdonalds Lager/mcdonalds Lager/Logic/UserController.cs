using mcdonalds_Lager.Præsentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Logic
{

    internal class UserController
    {
        static string[] mainMenuTitels = { "Ingredients", "Orders", "Drinks" };
        static string[] drinksMenuTitels = { "Water", "Juice", "Soda", "Frappe", "Milkshake", "Coffe", "Alcohol" };
        static string[] ingredientsTitels = { "Meat", "Cheese", "Bread", "Dressing And Dip", "Salad", "Fruits" };
        public static void Controller()
        {
            box box = Gui.DrawMenu(mainMenuTitels);

            int x = 0;
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {

                    case ConsoleKey.Tab:
                        break;

                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            ConsoleDraw.Draw(mainMenuTitels[x], box.ySplit[x] + 1, box.ySize + 1, ConsoleColor.White);
                            x--;
                            ConsoleDraw.Draw(mainMenuTitels[x], box.ySplit[x] + 1, box.ySize + 1, ConsoleColor.DarkRed);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < box.ySplit.Count - 1)
                        {
                            ConsoleDraw.Draw(mainMenuTitels[x], box.ySplit[x] + 1, box.ySize + 1, ConsoleColor.White);
                            x++;
                            ConsoleDraw.Draw(mainMenuTitels[x], box.ySplit[x] + 1, box.ySize + 1, ConsoleColor.DarkRed);
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (x)
                        {
                            case 0:
                                box = Gui.DrawMenu(ingredientsTitels);
                                break;
                            case 1:
                                box = Gui.DrawMenu(mainMenuTitels);
                                break;
                            case 2:
                                box = Gui.DrawMenu(drinksMenuTitels);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
