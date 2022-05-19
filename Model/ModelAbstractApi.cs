using Logika;
using System.Collections;


//model - warstwa zarzadzajaca logika na potrzeby widoku "view"
namespace Model
{
    public abstract class ModelAbstractApi
    {
        public abstract int Wielkosc { get; }
        public abstract IList KulkiModelu(int id);
        public abstract void Start();
        public abstract void Stop();
        public abstract int getX(int i);
        public abstract int getY(int i);
        public abstract int getWielkosc(int i);

        public static ModelAbstractApi CreateApi(int Wielkosc)
        {
            return new ModelApi(Wielkosc);
        }
    }
    internal class ModelApi : ModelAbstractApi
    {
        public override int Wielkosc { get; }
        private LogikaAbstractApi logika;

        public ModelApi(int Wielkosc)
        {
            logika = LogikaAbstractApi.CreateLayer();
            Wielkosc = Wielkosc;
        }

        public override int getX(int i)
        {
            return logika.getX(i);
        }

        public override int getY(int i)
        {
            return logika.getY(i);
        }

        public override int getWielkosc(int i)
        {
            return logika.getWielkosc(i);
        }
        public override IList KulkiModelu(int id) => logika.StworzListeKulek(id);

        public override void Start()
        {
            logika.Start();
        }

        public override void Stop()
        {
            logika.Stop();
        }
    }
}