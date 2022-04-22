using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    internal class Kulka : KulkiAPI
    {
        private int ID;
        public Kulka(int id, int x, int y, int x_ruch, int y_ruch)
        {
            ID = id;
            X = x;
            Y = y;
            X_ruch = x_ruch;
            Y_ruch = y_ruch;
        }
    }

    public override int GetID()
    {
        return ID;
    }
}
