using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading;

namespace Dane
{

    public abstract class DaneAbstractApi
    {
        public int Wielkosc { get; set; }
        public abstract int GetIlosc();
        public abstract IList StworzKulki(int ilosc);
        public abstract IBall GetKulke(int id);
        public abstract int getWielkosc(int i);
        public static DaneAbstractApi CreateApi()
        {
            return new DaneApi();
        }
    }
    internal class DaneApi : DaneAbstractApi
    {
        public new readonly int Wielkosc = Pudelko.Wielkosc;
        public DaneApi()
        {
            kulki = new ObservableCollection<IBall>();
            Wielkosc = Pudelko.Wielkosc;
        }
        private ObservableCollection<IBall> kulki { get; }
        public ObservableCollection<IBall> Kulki => kulki;
        public override int getWielkosc(int i)
        {
            return 2 * kulki[i].PR;
        }

        public override IList StworzKulki(int number)
        {
            Random rand = new Random();
            Mutex mute = new Mutex();
            if (number > 0)
            {
                int licznik = kulki.Count;
                for (int i = 0; i < number; i++)
                {
                    mute.WaitOne();
                    int pr = 10;
                    double w = 30;
                    int x = rand.Next(pr, Pudelko.Wielkosc - pr);
                    int y = rand.Next(pr, Pudelko.Wielkosc - pr);
                    Kulki k = new Kulki(i, x, y, pr, w);
                    kulki.Add(k);
                    mute.ReleaseMutex();
                }
            }
            return kulki;
        }
        public override int GetIlosc()
        {
            return kulki.Count;
        }
        public override IBall GetKulke(int id)
        {
            return kulki[id];
        }
    }
}