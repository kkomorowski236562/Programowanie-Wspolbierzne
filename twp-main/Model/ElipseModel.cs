using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace Model
{
    public class ElipseModel
    {
        private int Radius;
        private int Posx;
        private int Posy;
        public ElipseModel(Ball ball)
        {
            this.Radius = ball.R;
            this.Posx = ball.X;
            this.Posy = ball.Y;
        }
    }
}
