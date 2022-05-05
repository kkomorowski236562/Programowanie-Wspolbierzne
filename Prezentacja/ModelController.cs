using Logika;
using System;
using System.Collections.Generic;
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
        public abstract int getSize();
        public abstract void dodaj_kulke(int ilosc);

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
            }

            public override void Stop()
            {
                logika.Stop();
            }


            override public int getSize()
            {
                return logika.Wielkosc_pudelka();
            }

            public override void dodaj_kulke(int ilosc)
            {
                for( int i = 0; i< ilosc; i++ )
                {
                    logika.dodaj_kulke();
                    Circles.Add(new Model1(logika.dodaj_kulke()));

                }

            }

        }
    }
}
