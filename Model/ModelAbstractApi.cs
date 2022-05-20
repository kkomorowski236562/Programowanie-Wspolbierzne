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