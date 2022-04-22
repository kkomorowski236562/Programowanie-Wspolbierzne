using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public abstract class PudelkoApi
    {
        public static PudelkoApi stworz_pudelko(int x, int y)
        {
            return new Pudelko(x, y);
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
