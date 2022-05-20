using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Dane
{
    public interface IBall : INotifyPropertyChanged
    {
        int x { get; set; }
        int y { get; set; }
        int ID { get; }
        int PR { get; }
        double Waga { get; }
        void Ruch();
        void Reset();
        void CreateTask(int Przedzial);
    }
    internal class Kulki : IBall
    {
        private int X;
        private int Y;
        private int id;
        private readonly int Pr;
        private readonly double waga;
        private bool stop = false;
        private Task task;
        private Stopwatch stopwatch = new Stopwatch();
        public event PropertyChangedEventHandler PropertyChanged;
        internal void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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
        public double Waga { get => waga;}
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
        public int ID { get => id; }

        public Kulki(int id, int X, int Y, int Pr, double waga)
        {
            this.id = id;
            this.X = X;
            this.Y = Y;
            this.Pr = Pr;
            this.waga = waga;
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
                }
                stopwatch.Stop();

                await Task.Delay((int)(Przedzial - stopwatch.ElapsedMilliseconds));
            }
        }
    }
}
