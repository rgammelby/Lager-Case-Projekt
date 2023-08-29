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
<<<<<<< HEAD
            SqlConnection s = DataAccessLayer.GetConnection();
            s.Open();
=======
            Console.CursorVisible = false;
            //SqlConnection s = DataAccessLayer.GetConnection();
            //s.Open();
>>>>>>> 7e63d970f059e24ba1110fa4942b2fa65c89e49d
            
            Console.SetWindowSize(170,45);
            //UserController.Controller();
            DataAccessLayer.Print(s, "Coffee");
            Console.ReadLine();
        }
    }
}
