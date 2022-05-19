using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Dane
{

    public abstract class DaneAbstractApi
    {
        public int Wielkosc { get; set; }
        public abstract int GetIlosc();
        public abstract void OdswiezKulki();
        public abstract bool WykryjPokrycie(Kulki k1, Kulki k2);
        public abstract void RuchKulki(Kulki k);
        public abstract IList StworzKulki(int ilosc);
        public abstract int getX(int i);
        public abstract int getY(int i);
        public abstract int getDiagonal(int i);
        public abstract int getWielkosc();
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
            kulki = new ObservableCollection<Kulki>();
            Wielkosc = Pudelko.Wielkosc;
        }
        private ObservableCollection<Kulki> kulki { get; }
        public ObservableCollection<Kulki> Kulki => kulki;
        public override int getWielkosc()
        {
            return Wielkosc;
        }

        public override int getX(int i)
        {
            return kulki[i].x;
        }
        public override int getY(int i)
        {
            return kulki[i].y;
        }
        public override int getDiagonal(int i)
        {
            return 2 * kulki[i].PR;
        }

        public override IList StworzKulki(int number)
        {
            Random rand = new Random();
            if (number > 0)
            {
                for (int i = 0; i < number; i++)
                {
                    int pr = 20;
                    int x = rand.Next(pr, Pudelko.Wielkosc - pr);
                    int y = rand.Next(pr, Pudelko.Wielkosc - pr);
                    Kulki ball = new Kulki(i, x, y, pr);
                    kulki.Add(ball);
                }
            }
            return kulki;
        }

        public override void RuchKulki(Kulki k)
        {
            if (k.x + k.PR < Pudelko.Wielkosc - k.PR && k.x + k.PR >= 0)
            {
                k.x = k.x + k.PR;
            }
            else
            {
                if (k.x + k.PR >= Pudelko.Wielkosc)
                {
                    k.x = Pudelko.Wielkosc - k.PR;
                }
                else
                {
                    k.x = k.PR;
                }
                k.PR *= -1;
            }

            if (k.y + k.PR < Pudelko.Wielkosc - k.PR && k.y + k.PR > 0)
            {
                k.y = k.y + k.PR;
            }
            else
            {
                if (k.y + k.PR >= Pudelko.Wielkosc)
                {
                    k.y = Pudelko.Wielkosc - k.PR;
                }
                else
                {
                    k.y = k.PR;
                }
                k.PR *= -1;
            }

        }
        public override int GetIlosc()
        {
            int counter = 0;
            foreach (Kulki k in kulki)
            {
                counter += 1;
            }
            return counter;
        }

        public override void OdswiezKulki()
        {
            foreach (Kulki k in kulki)
            {
                RuchKulki(k);
            }
            for (int i = 0; i < kulki.Count; i++)
            {
                for (int j = 0; j < kulki.Count; j++)
                {
                    if (i != j)
                    {
                        if (WykryjPokrycie(kulki[i], kulki[j]))
                        {
                            kulki[i].PR *= -1;
                            kulki[j].PR *= -1;
                        }
                    }
                }
            }
        }

        public override bool WykryjPokrycie(Kulki k1, Kulki k2)
        {
            bool flag = false;

            if ((k1.x - k2.x <= k2.PR) && (k1.y - k2.y == k2.PR))
            {
                flag = true;
            }

            return flag;
        }

    }
}