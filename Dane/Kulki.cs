using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Dane
{
    public class Kulki
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int ID { get; private set; }
        private readonly int Pr;
        private bool stop { get; set; }
        private Task task { get; set; }
        private Stopwatch stopwatch = new Stopwatch();
        public int PR 
        { 
            get => Pr; 
            set
            {
                if (value.Equals(Pr))
                    return;
                PR = value;
            }
        }
        public int x 
        { 
            get => X; 
            set
            {
                if (value.Equals(X))
                    return;
                x = value;
            }
        }
        public int y 
        {
            get => Y;
            set
            {
                if (value.Equals(Y))
                    return;
                y = value;
            }
        }

        public Kulki(int ID, int X, int Y, int Pr)
        {
            this.ID = ID;
            this.X = X;
            this.Y = Y;
            this.x = X;
            this.y = Y;
            this.Pr = Pr;
        }

        public void Ruch()
        {
            x = X + PR;
            y = Y + PR;
        }

        public void CreateTask(int Przedzial)
        {
            stop = false;
            task = Run(Przedzial);
        }

        public void Reset()
        {
            stop = true;
        }

        private async Task Run(int Przedzial)
        {
            while (!stop)
            {
                stopwatch.Reset();
                stopwatch.Start();
                if (!stop)
                {
                    Ruch();
                    await Task.Delay((int)(Przedzial - stopwatch.ElapsedMilliseconds));
                }
            }
        }
    }
}
