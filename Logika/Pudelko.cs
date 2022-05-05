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

        public int Size { get; set; }
        public List<Kulki>? Kulkis { get; private set; }

        public void stworz_kulki(int ilosc)
        {
            for (int i = 0; i < ilosc; i++)
            {
                Random rand = new Random();
                int X = rand.Next(-Size, Size);
                int Y = rand.Next(-Size, Size);
                int SzX = rand.Next(1,3);
                int SzY = rand.Next(1,3);
                Kulkis.Add( new Kulki(i+1, X, Y, SzX, SzY));   
            }
        }

        public void moveKulke()
        {
            for(int i =0; i<Kulkis.Sum(); i++)
                kulka.move(Size);
        }
    }
}
