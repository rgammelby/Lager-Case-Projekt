using mcdonalds_Lager.Dal;
using mcdonalds_Lager.Præsentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Logic
{
    internal class Buy
    {
        /// <summary>
        /// gets User input
        /// </summary>
        /// <returns></returns>
        public static string GetInput()
        {
            var input = Console.ReadLine();

            return input;
        }
        public static dynamic Input()
        {
            Console.Clear();
            // draws input field at console x, y; change as needed
            BuyMenu.InputField(0, 0);

            // retrives and evalutes input
            var input = GetInput();
            var valid = Validators.InputValidator(input);

            //displays error if valid evalutes to false
            if (valid == false)
            {
                InputError();
                Console.ReadLine();
                Input();
            }
                

            var inputI = 0;
            var inputF = 0.0;
            bool inputIsInt = false;

            try
            {
                // if able to convert input to int, return int
                inputI = Convert.ToInt32(input);
                inputIsInt = true;
            }
            catch
            {
                try
                {
                    // if not able to convert input to int, return float
                    inputF = float.Parse(input);
                }
                catch
                {
                    InputError();
                    Console.ReadLine();
                    Input();

                }
            }


            // returns input in int or float format
            if (inputIsInt)
                return inputI;

            else
                return inputF;
        }
        // outputs error if input not valid
        static void InputError()
        {
            ConsoleDraw.Draw("Invalid input. Make sure input is a number, containing no letters, punctuation or whitespace.",0,3, ConsoleColor.Red);

        }
    }
}
