using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public abstract class PudelkoApi
    {
        public static PudelkoApi stworz_pudelko()
        {
            Console.WriteLine("Podaj wielkosc planszy (X:Y)");
            string xs = Console.ReadLine();
            string ys = Console.ReadLine();
            int x = Convert.ToInt32(xs);
            int y = Convert.ToInt32(ys);
            return new Pudelko(x, y);
        }
        public int X { get; set; }

        public int getNegX()
        {
            return -X;
        }

        public int getNegY()
        {
            return -Y;
        }
        public int Y { get; set; }
    }
}
