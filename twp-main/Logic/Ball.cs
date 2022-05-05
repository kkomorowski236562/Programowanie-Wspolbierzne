using System;

namespace Logic
{
    public class Ball
    {
        private int vx;
        private int vy;

        public int X {get; private set; }
        public int Y { get; private set; }
        public int R { get; private set; }

        public int VelX { get; private set; }
        public int VelY { get; private set; }


        public Ball(int x, int y, int r, int vx, int vy)
        {
            this.X = x;
            this.Y = y;
            this.R = r;
            this.VelX = vx;
            this.VelY = vy;
        }

        public void simulateMove(int size)
        {
            
            int newx = X + VelX;
            int newy = Y + VelY;

            if(newx > size || newx < 0)
            {
                VelX *= -1;
            }
            if (newy > size || newy < 0)
            {
                VelY *= -1;
            }

            X += VelX;
            Y += VelY;
        }
    }
}
