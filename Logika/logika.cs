using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public abstract class logika
    {
        private int ruch_x;
        private int ruch_y;
        public void pokaz_wspolrzedne()
        {
            Console.WriteLine(x, ", ", y);
        }
        public void ruch_kulki()
        {
            Random rnd = new Random(2);
            ruch_x = rnd.Next();
            rnd = new Random(2);
            ruch_y = rnd.Next();
            switch (ruch_x)
            {
                case 0:
                    x++;
                    break;
                case 1:
                    x--;
                    break;
                default:
                    x = x;
                    break;
            }
            switch (ruch_y)
            {
                case 0:
                    y++;
                    break;
                case 1:
                    y--;
                    break;
                default:
                    y = y;
                    break;
            }

        }
    }
}
