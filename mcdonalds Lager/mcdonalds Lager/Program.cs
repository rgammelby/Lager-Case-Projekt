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
        static void Main()
        {
            SqlConnection s = DataAccessLayer.GetConnection();
            s.Open();

            Console.SetWindowSize(170,45);
            Gui.DrawMainMenu();
            DataAccessLayer.Select(s, "Coffee");
            Console.ReadLine();
        }
    }
}
