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
        private int ruch;
        public stworz_kulke()
        {
            Random rnd = new Random();
            x = rnd.Next(10);
            y = rnd.Next(10);
        }

        public pokaz_wspolrzedne()
        {
            Console.WriteLine(x, ", ", y);
        }

        public ruch_kulki() //dla pola od 10x10 od 0 do 9, ale to ruch to raczej do zmiany XD
        {
            Random rnd = new Random(4);
            ruch = rnd.Next();
            switch (ruch)
            {
                case 0:
                    x++;
                    y++;
                    if (x == 9 && y == 9) case 3;
                    if (x == 9) case 1;
                    if (y == 9) case 2;
                    break;
                case 1:
                    x--;
                    y++;
                    if (x == 0 && y == 9) case 2;
                    if (x == 0) case 0;
                    if (y == 9) case 3;
                    break;
                case 2:
                    x++;
                    y--;
                    if (x == 9 && y == 0) case 1;
                    if (x == 9) case 3;
                    if (y == 0) case 0;
                case 3:
                    x--;
                    y--;
                    if (x == 0 && y == 0) case 0;
                    if (x == 0) case 2;
                    if (y == 0) case 1;
                default:
                    break;
            }
     
        }
    }
}
