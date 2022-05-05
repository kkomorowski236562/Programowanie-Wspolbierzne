using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Kulki
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int ID { get; private set; }
        public int SzX { get; private set; }
        public int SzY { get; private set; }

        public Kulki(int id, int X, int Y, int SzX, int SzY)
        {
            Random rand = new Random();
            this.ID = id;
            this.X = X;
            this.Y = Y;
            this.SzX = SzX;
            this.SzY = SzY;
        }

        public void move(int Wielkosc)
        {
            int NX = X + SzX;
            int NY = Y + SzY;

            if( NX > Wielkosc || NX < 0)
                SzX *= -1;
            if( NY > Wielkosc || NY < 0)
                SzY *= -1;
            X += SzX;
            Y += SzY;
        }
    }
}
