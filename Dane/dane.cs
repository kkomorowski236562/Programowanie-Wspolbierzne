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
        private int ruch;

        public ustal_wspolrzedne(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

