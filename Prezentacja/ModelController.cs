using Logika;
using System;
using System.Collections.ObjectModel;

namespace Model
{
    public abstract class ModelController
    {
        private logika logika;
        public static ModelController CreateLayer(Logika.logika L = default(logika))
        {
            return new Object(L == null ? logika.CreateLayer() : L);
        }

        public abstract ObservableCollection<Model1> GetModels();

        public abstract void Start();
        public abstract void Stop();

        //public abstract void Start();
        public abstract int GetSize();
        public abstract void Add_Ball(int ilosc);

        // implementacja Api
        private class Object : ModelController
        {
            private ObservableCollection<Model1> Circles = new ObservableCollection<Model1>();

            public override ObservableCollection<Model1> GetModels()
            {
                return Circles;
            }
            public Object(logika l)
            {
                logika = l;
            }

            override public void Start()
            {
                logika.Start();
                Console.WriteLine("hello");
            }

            public override void Stop()
            {
                logika.Stop();
            }

            override public int GetSize()
            {
                return logika.Wielkosc_pudelka();
            }

            public override void Add_Ball(int ilosc)
            {
                for (int i = 0; i < ilosc; i++)
                {
                    logika.Dodaj_kulke();
                    Circles.Add(new Model1(logika.Dodaj_kulke()));
                }
            }
        }
    }
}
