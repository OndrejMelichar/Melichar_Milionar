using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melichar_Milionar
{
    class Otazka
    {
        private string textOtazky;
        private List<string> odpovedi;
        private int uroven;

        public Otazka(string textOtazky, List<string> odpovedi, int uroven)
        {
            this.textOtazky = textOtazky;
            this.odpovedi = odpovedi;
            this.uroven = uroven;
        }

        public string TextOtazky
        {
            get { return textOtazky; }
        }

        public List<string> Odpovedi
        {
            get { return odpovedi; }
        }

        public int Uroven
        {
            get { return uroven; }
        }

    }
}
