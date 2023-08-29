using mcdonalds_Lager.Præsentation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager
{
    public class DataAccessLayer
    {
        // returns connection string for linked database
        public static SqlConnection GetConnection()
        {
            // not to be included in final push; .gitignore
            return new SqlConnection(@"Data Source = localhost; Initial Catalog = Storage; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        // method for freestyle script execution, accepts a script as parameter
        public static void ExecuteScript(string script, SqlConnection s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(script);

            string sqlQuery = sb.ToString();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, s))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // sends 'select' query and prints result
        public static DataTable GetData(string script)
        {
            SqlConnection s = GetConnection();
            s.Open();
            ExecuteScript(script, s);

            DataTable dt = new DataTable();  // DataTable declaration
            SqlDataAdapter sda = new SqlDataAdapter(script, s);

            sda.Fill(dt);  // fills datatable

            s.Dispose();  // disposes of the opened connection

            return dt;
        }
        // PRINT
        public static void Print(SqlConnection s, string table)
        {
            var x = 0;

            // whatever select script, in this case selects & prints top 5 entries (coffee_type and litres) from the coffee table (hehe) 
            var script = $"SELECT * FROM {table}";

            var dt = GetData(script);

            Console.WriteLine("\n");

            // prints column names
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                Console.Write($"{dt.Columns[i]}    ");
            }

            Console.WriteLine("\n");

            // prints extracted data, spaced by 15 pr. column.
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var cursorLeft = 0;
                for (int n = 1; n < dt.Rows[i].ItemArray.Length; n++)
                {
                    if (n % dt.Rows.Count - 1 == 0)
                        Console.CursorLeft = cursorLeft;
                    else
                        Console.CursorLeft = cursorLeft += 15;

                    Console.Write($"{dt.Rows[i].ItemArray[n]}");
                }
                Console.Write("\n");
            }
        }

        static dynamic Input()
        {
            // draws input field at console x, y; change as needed
            InputField(0, 0);

            // retrives and evalutes input
            var input = GetInput();
            var valid = InputValidator(input);

            //displays error if valid evalutes to false
            if (valid == false)
                InputError();

            // if valid, confirms input validity, mainly for testing
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nInput is valid. ");
                Console.ResetColor();
            }

            var inputI = 0;
            var inputF = 0.0;
            bool inputIsInt;

            // writes here also mainly for testing
            try
            {
                // if able to convert input to int, return int
                inputI = Convert.ToInt32(input);
                Console.WriteLine("int input: " + input);
                inputIsInt = true;
            }
            catch
            {
                // if not able to convert input to int, return float
                inputF = float.Parse(input);
                Console.WriteLine("Input is in float format. ");
                inputIsInt = false;
            }

            // also mainly for testing, remove as needed
            Console.ReadLine();

            // returns input in int or float format
            if (inputIsInt)
                return inputI;

            else 
                return inputF;
        }

        // gets input
        static string GetInput()
        {
            var input = Console.ReadLine();

            return input;
        }

        // draws input field at console position x, y
        static void InputField(int x, int y)
        {
            box box = new box();
            ConsoleDraw.DrawBox(30, 2, x, y);
            Console.SetCursorPosition(x + 1, y + 1);
        }

        // outputs error if input not valid
        static void InputError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid input. Make sure input is a number, containing no letters, punctuation or whitespace.");
            Console.ResetColor();
        }

        // evalutes input validity true/false
        static bool InputValidator(string input)
        {
            var valid = false;

            for (int i = 0; i < input.Length; i++)
            {
                // if each character of string input is NOT a letter, punctuation or whitespace
                if (!char.IsLetter(input[i]) && !char.IsPunctuation(input[i]) && !char.IsWhiteSpace(input[i]))
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
