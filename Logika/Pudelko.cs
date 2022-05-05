using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Pudelko
    {
        public Pudelko(int size)
        {
            this.Size = size;
            this.Kulkis = new List<Kulki>();
        }

        private int number = 0;
        public int Size { get; set; }
        public List<Kulki> Kulkis { get; private set; }

        public Kulki stworz_kulki()
        {
            number++;
            Kulki k;
            Random rand = new Random();
            int X = rand.Next(-Size, Size);
            int Y = rand.Next(-Size, Size);
            int SzX = rand.Next(1,3);
            int SzY = rand.Next(1,3);
            k = new Kulki(number, X, Y, SzX, SzY);
            Kulkis.Add( new Kulki(number, X, Y, SzX, SzY));   
            return k;
        }

        public void moveKulke()
        {
            for(int i =0; i<Kulkis.Count(); i++)
                Kulkis[i].move(Size);
        }
    }
}
