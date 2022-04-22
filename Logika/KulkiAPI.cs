using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public abstract class KulkiApi
    {
        public abstract int GetID();
        public static KulkiApi stworz_kulke(int id, int x, int y, int x_ruch, int y_ruch)
        {
            return new Kulki(id, x, y, x_ruch, y_ruch);
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int X_ruch { get; set; }
        public int Y_ruch { get; set; }
        public int ID { get; set; }
    }
}
