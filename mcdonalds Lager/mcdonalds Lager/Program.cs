using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager
{
    internal class Program
    {
        static void Main()
        {
            Gui.box box = new Gui.box();
            box = Gui.DrawBox(10, 10, 2, 2);
            Gui.SplitBoxVertical(box, 5);
            Console.ReadLine();
        }
    }
}
