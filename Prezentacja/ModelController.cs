using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logika;

namespace Model
{
    public abstract class ModelController
    {
        private Logika l;
        public static ModelController CreateLayer(Logika.logika L = default(logika))
        {
            return new Object(L == null ? logika.CreateLayer() : L);
        }

        public abstract ObservableCollection<Model> GetModels();

        public abstract void Start();
        public abstract void Stop();

        //public abstract void Start();
        public abstract int getSize();
        public abstract void dodaj_kulke(int ilosc);

        // implementacja Api
        private class Object : ModelController
        {
            private ObservableCollection<Model> Circles = new ObservableCollection<Model>();

            public override ObservableCollection<Model> GetModels()
            {
                return Circles;
            }
            public Object(logika l)
            {
                logika = l;
            }

            override public void StartMoving()
            {
                logika.Start();
            }

            public override void StopMoving()
            {
                logika.Stop();
            }


            override public int getSize()
            {
                return logika.PudelkoSize();
            }

            public override void dodaj_kulke(int ilosc)
            {
                for( int i = 0; i< ilosc; i++ )
                {
                    logika.addKulki();
                    Circles.Add(new Model(logika.addKulki()));

                }

            }

        }
    }
}
