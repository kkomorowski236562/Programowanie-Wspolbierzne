using System;
using System.Collections.Generic;
using System.Text;
using Logika;

namespace Model
{
    public class Model
    {
        private int Promien = 5;
        private int PosX;
        private int PosY;
        public Model(Kulki k)
        {
            this.PosX = k.X;
            this.PosY = k.Y;
        }
    }
}
