using Dane;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Logic
{
    public abstract class logika
    {

        public static logika CreateLayer(DaneApi dane = default(DaneApi))
        {
            return new BusinessLogika(dane == null ? DaneApi.Create() : dane);
        }

        public abstract List<Kulki> Tablica_kulek();
        public abstract int Ilosc_kulek();
        public abstract int Wielkosc_pudelka();
        public abstract void Start();
        public abstract void Stop();

        public abstract Kulka Dodaj_kulke();

        private class BusinessLogika : logika
        {
            public Task positionUpdater { get; private set; }
            public Pudelko map = new Pudelko(300);
            private readonly DaneApi WarstwaDanych;
            private bool running;


            public BusinessLogika(DaneApi dataLayerAPI)
            {
                WarstwaDanych = dataLayerAPI;
            }

            public override void Start()
            {
                this.running = true;
                positionUpdater = new Task(MoveBallsInLoop);
                positionUpdater.Start();
            }


            private void MoveBallsInLoop()
            {
                while (this.running)
                {
                    map.MoveBalls();
                    Thread.Sleep(10);
                }
            }

            public override void Stop()
            {
                this.running = false;
            }

            override public List<Kulki> Tablica_kulek()
            {
                return map.Kulki;
            }
            override public int Ilosc_kulek()
            {
                return map.Kulki.Count;
            }
            override public int Wielkosc_pudelka()
            {
                return map.Size;
            }
            public override Kulki dodaj_kulke()
            {
                return map.stworz_kulki(1);
            }
        }

    }
}
