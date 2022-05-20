using Dane;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;


namespace Logika
{
    public abstract class LogikaAbstractApi
    {
        public abstract int Wielkosc { get; }
        public abstract int Ilosc { get; }
        //gettery do danych
        public abstract int getWielkosc(int i);
        public abstract int getIlosc();
        //funkcje obslugujace warstwe danych poprzez logike
        public abstract IList StworzListeKulek(int ilosc);
        public abstract void Start();
        public abstract void Stop();
        public abstract IBall getKulke(int i);
        public abstract void Sciana(IBall kulka);
        public abstract void Negacja(IBall kulka);
        public abstract void OdswiezKulke(object s, PropertyChangedEventArgs args);
        public static LogikaAbstractApi CreateLayer()
        {
            return new LogikaApi();
        }
    }
    internal class LogikaApi : LogikaAbstractApi
    {
        // wskaznik na klase przechowujaca dane o kulkach i pudelku
        private DaneAbstractApi dane;
        // reszta parametrow klasy Logika / Threading tasks
        private int wielkosc;
        private int ilosc;
        public override int Wielkosc { get; }
        public override int Ilosc { get; }
        private readonly Mutex mute = new Mutex();
        // konstruktor
        public LogikaApi()
        {
            dane = DaneAbstractApi.CreateApi();
            this.wielkosc = dane.Wielkosc;
        }
        // funckje zadeklarowane w klasie rodzicu
        public override int getWielkosc(int i)
        {
            return dane.getWielkosc(i);
        }
        public override int getIlosc()
        {
            return dane.GetIlosc();
        }
        public override IBall getKulke(int i)
        {
            return dane.GetKulke(i);
        }
        public override IList StworzListeKulek(int ilosc)
        {
            int y = dane.GetIlosc();
            IList pom = dane.StworzKulki(y);
            for (int i = 0; i < dane.GetIlosc() - y; i++)
                dane.GetKulke(ilosc + i).PropertyChanged += OdswiezKulke;
            return pom;
        }
        public override void Sciana(IBall kulka)
        {
            int d = kulka.PR * 2;
            int wboarder = this.Wielkosc - d;
            int hboarder = this.Wielkosc - d;
            if (kulka.x <= 0)
                kulka.x = -kulka.x;
            else if (kulka.x >= wboarder)
                kulka.x = wboarder - (kulka.x - hboarder);
            if (kulka.y <= 0)
                kulka.y = -kulka.y;
            else if (kulka.y >= hboarder)
                kulka.y = hboarder - (kulka.y - wboarder);
        }
        public override async void Negacja(IBall k)
        {
            for (int i = 0; i < dane.GetIlosc(); i++)
            {
                IBall k2 = dane.GetKulke(i);
                if (k.ID == k2.ID)
                {
                    continue;
                }
                if (Kolizja(k, k2))
                {
                    double m1 = k.Waga;
                    double m2 = k2.Waga;
                    double v1x = k.x;
                    double v1y = k.y;
                    double v2x = k2.x;
                    double v2y = k2.y;
                    double u1x = (m1 - m2) * v1x / (m1 + m2) + (2 * m2) * v2x / (m1 + m2);
                    double u1y = (m1 - m2) * v1y / (m1 + m2) + (2 * m2) * v2y / (m1 + m2);
                    double u2x = 2 * m1 * v1x / (m1 + m2) + (m2 - m1) * v2x / (m1 + m2);
                    double u2y = 2 * m1 * v1y / (m1 + m2) + (m2 - m1) * v2y / (m1 + m2);
                    k.x = (int)u1x;
                    k.y = (int)u1y;
                    k2.x = (int)u2x;
                    k2.y = (int)u2y;
                }
            }
        }
        internal bool Kolizja(IBall k1, IBall k2)
        {
            bool f = false;
            if (k1 == null || k2 == null)
                return false;
            if (Dystans(k1, k2) <= (2 * k1.PR))
                f = true;
            return f;
        }

        public override void OdswiezKulke(object s, PropertyChangedEventArgs args)
        {
            IBall k = (IBall)s;
            mute.WaitOne();
            Sciana(k);
            Negacja(k);
            mute.ReleaseMutex();
        }

        internal double Dystans(IBall k1, IBall k2)
        {
            double x1 = k1.x + k1.PR + k1.x;
            double y1 = k1.y + k1.PR + k1.y;
            double x2 = k1.y + k1.PR + k1.x;
            double y2 = k1.x + k1.PR + k1.y;
            return Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        }

        public override void Start()
        {
            for (int i = 0; i < dane.GetIlosc(); i++)
                dane.GetKulke(i).CreateTask(30);
        }

        public override void Stop()
        {
            for (int i = 0; i < dane.GetIlosc(); i++)
                dane.GetKulke(i).Reset();
        }
    }
}
