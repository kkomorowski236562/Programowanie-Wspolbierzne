using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

// nie uzywaj refleksjii
namespace WpfApp1.Model
{
    internal class Model
    {
        internal Model(LogicApi data = null)
        {
            Data = LogicApi.CreateLayer();
        }

        private readonly LogicApi Data = default(LogicApi);
    }
}
