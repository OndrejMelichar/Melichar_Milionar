using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melichar_Milionar
{
    class Hrac
    {
        private string jmeno;
        private int skore;
        private string datum;

        public string Jmeno
        {
            get { return jmeno; }
            set { jmeno = value; }
        }

        public int Skore
        {
            get { return skore; }
            set { skore = value; }
        }

        public string Datum
        {
            get { return datum; }
            set { datum = value; }
        }

    }
}
