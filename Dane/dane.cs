using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class dane
    {
        private int Id { get; set; }
        private int x;
        private int y;
        public void stworz_kulke()
        {
            Random rnd = new Random();
            x = rnd.Next();
            y = rnd.Next();
        }
        public void ustal_wspolrzedne(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

