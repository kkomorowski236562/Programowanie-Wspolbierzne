using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public abstract class KulkiApi
    {
        private PudelkoApi P;
        public abstract int GetID();
        public static KulkiApi stworz_kulke()
        {
            Console.WriteLine("Podaj ilosc kulek: ");
            string kule = Console.ReadLine();
            int kule2 = Convert.ToInt32(kule);
            int[] ilosc_id = new int[kule2];
            for (int i = 0; i < kule2; i++)
            {
                ilosc_id[i] = i + 1;
                return new Kulki(ilosc_id[i]);
            }
            return new Kulki(1);
        }

        public PudelkoApi getP()
        {
            return P;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int ID { get; set; }
    }
}
