using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melichar_Milionar
{
    class Otazkovator
    {
        private Random random = new Random();
        
        private List<Otazka> otazky;
        private int indexSpravneOdpovedi;

        public int IndexSpravneOdpovedi
        {
            get { return indexSpravneOdpovedi; }
        }


        public Otazkovator()
        {
            Souborovator souborovator = new Souborovator();
            this.otazky = souborovator.NactiOtazky();
        }

        public Otazka VytvorOtazku(int uroven)
        {
            List<Otazka> otazkyPodleUrovne = new List<Otazka>();

            foreach (Otazka otazka in this.otazky)
            {
                if (otazka.Uroven == uroven)
                {
                    otazkyPodleUrovne.Add(otazka);
                }
            }

            if (otazkyPodleUrovne.Count > 0)
            {
                return otazkyPodleUrovne[this.random.Next(otazkyPodleUrovne.Count)];
            }

            return null;
        }

        public List<string> RandomizujOdpovedi(List<string> razeneOdpovedi)
        {
            List<string> randomizovaneOdpovedi = new List<string>();

            bool poprve = true;
            int randomIndex = 0;
            while (razeneOdpovedi.Count > 0)
            {
                randomIndex = this.random.Next(0, razeneOdpovedi.Count);
                randomizovaneOdpovedi.Add(razeneOdpovedi[randomIndex]);
                razeneOdpovedi.RemoveAt(randomIndex);

                if (poprve && randomIndex == 0)
                {
                    this.indexSpravneOdpovedi = randomizovaneOdpovedi.Count - 1;
                    poprve = false;
                }
            }

            return randomizovaneOdpovedi;
        }

    }
}
