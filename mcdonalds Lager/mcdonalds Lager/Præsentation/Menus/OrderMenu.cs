using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Præsentation.Menus
{
    internal class OrderMenu
    {
        public static void DrawOrderMenu() 
        {
            Console.BackgroundColor = ConsoleColor.Blue;  
            Console.Clear();
            //Text "no orders :-("
            Console.WriteLine("\r\n███╗   ██╗ ██████╗      ██████╗ ██████╗ ██████╗ ███████╗██████╗ ███████╗              ██╗\r\n████╗  ██║██╔═══██╗    ██╔═══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔════╝    ██╗      ██╔╝\r\n██╔██╗ ██║██║   ██║    ██║   ██║██████╔╝██║  ██║█████╗  ██████╔╝███████╗    ╚═╝█████╗██║ \r\n██║╚██╗██║██║   ██║    ██║   ██║██╔══██╗██║  ██║██╔══╝  ██╔══██╗╚════██║    ██╗╚════╝██║ \r\n██║ ╚████║╚██████╔╝    ╚██████╔╝██║  ██║██████╔╝███████╗██║  ██║███████║    ╚═╝      ╚██╗\r\n╚═╝  ╚═══╝ ╚═════╝      ╚═════╝ ╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝              ╚═╝");
            Console.ResetColor();
        }
    }
}
