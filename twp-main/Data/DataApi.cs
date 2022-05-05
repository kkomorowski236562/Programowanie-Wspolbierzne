using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class DataApi
    {
            public abstract int Siema {get;}

            public abstract void Mkme();


            public static DataApi Create()
            {
                return new Dataset();
            }

            #region Layer implementation

            private class Dataset : DataApi
            {
                public override int Siema => 200;
                public override void Mkme()
                {
                    System.Console.WriteLine("sieam");
                }

            }
            #endregion Layer implementation

    }
}
