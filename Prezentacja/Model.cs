using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja
{
    public class Main
    {
        private readonly KulkiApi kule;
        
        internal Main(int width, int height)
        {
            width = kule.getP().X + 100;
            height = kule.getP().Y + 100;
            kule = KulkiApi.stworz_kulke();
        }
    }

}
