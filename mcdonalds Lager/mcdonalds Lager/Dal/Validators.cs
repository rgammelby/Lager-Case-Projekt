using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Dal
{
    internal class Validators
    {
        // evalutes input validity true/false
        public static bool InputValidator(string input)
        {
            var valid = false;

            for (int i = 0; i < input.Length; i++)
            {
                // if each character of string input is NOT a letter, punctuation or whitespace
                if (char.IsDigit(input[i]))
                    valid = true;

                // if a character of string input IS punctuation, but is full stop or comma
                else if (char.IsPunctuation(input[i]) && (input[i] == '.' || input[i] == ','))
                    valid = true;

                else
                {
                    valid = false;
                    break;
                }
            }

            return valid;
        }
    }
}
