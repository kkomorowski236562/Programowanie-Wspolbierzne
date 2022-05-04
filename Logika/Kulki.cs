using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    internal class Kulki : KulkiApi
    {
        public Kulki(int id)
        {
            Random rand = new Random();
            int ran = rand.Next(getP().X);
            int yan = rand.Next(getP().Y);
            ID = id;
            X = ran;
            Y = yan;
        }

        public void move()
        {
            while(true)
            {
                if(X>getP().getNegX() || Y>getP().getNegY())
                {
                    X--;
                    Y--;
                }
                if(X>getP().getNegX() || Y<getP().Y)
                {
                    X--;
                    Y++;
                }
                if(X<getP().X || Y<getP().Y)
                {
                    X++;
                    Y++;
                }
                if(X<getP().X || Y>getP().getNegY())
                {
                    X++;
                    Y--;
                }
            }
        }

        public override int GetID()
        {
            return ID;
        }
    }
}
