using Dane;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Logika
{
    public abstract class LogikaAbstractApi
    {
        //gettery do danych
        public abstract int getX(int i);
        public abstract int getY(int i);
        public abstract int getWielkosc(int i);
        public abstract int getIlosc();
        //funkcje obslugujace warstwe danych poprzez logike
        public abstract IList StworzListeKulek(int ilosc);
        public abstract void OdswiezKulki();
        public abstract void Start();
        public abstract void Stop();
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
        private List<Task> tasks;
        // konstruktor
        public LogikaApi()
        {
            dane = DaneAbstractApi.CreateApi();
        }
        // funckje zadeklarowane w klasie rodzicu
        public override int getX(int i)
        {
            return dane.getX(i);
        }
        public override int getY(int i)
        {
            return dane.getY(i);
        }
        public override int getWielkosc(int i)
        {
            return dane.getWielkosc(i);
        }
        public override int getIlosc()
        {
            return dane.GetIlosc();
        }
        public override IList StworzListeKulek(int ilosc) => dane.StworzKulki(ilosc);
        public override async void OdswiezKulki()
        {
            await Task.Delay(30);
            dane.OdswiezKulki();
        }

        public int Tasks
        {
            get => tasks.Count;
        }
        public override void Start()
        {
            tasks.Add(Task.Run(() => OdswiezKulki()));
        }

        public override void Stop()
        {

        }
    }
}
