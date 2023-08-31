using mcdonalds_Lager.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager
{
    internal class Program
    {
        public static void Main()
        {
            
            Console.SetWindowSize(170,45);
            Console.CursorVisible = false;
            UserController.MainAndTableController();
        }
    }
}
