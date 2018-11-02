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
            this.otazky = this.nactiOtazky();
        }


        private List<Otazka> nactiOtazky()
        {
            List<Otazka> otazky = new List<Otazka>();

            if (File.Exists(@"otazky.xlsx"))
            {
                var package = new ExcelPackage(new FileInfo(@"otazky.xlsx"));
                ExcelWorksheet workSheet = package.Workbook.Worksheets["List1"];
                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;


                string textOtazky;
                List<string> moznosti;
                int uroven;
                bool prevod;

                for (int row = start.Row; row <= end.Row; row++)
                {
                    moznosti = new List<string>();

                    textOtazky = workSheet.Cells[row, start.Column].Text;

                    moznosti.Add(workSheet.Cells[row, start.Column + 1].Text);
                    moznosti.Add(workSheet.Cells[row, start.Column + 2].Text);
                    moznosti.Add(workSheet.Cells[row, start.Column + 3].Text);
                    moznosti.Add(workSheet.Cells[row, start.Column + 4].Text);

                    prevod = int.TryParse(workSheet.Cells[row, start.Column + 5].Text, out uroven);

                    if (!prevod)
                    {
                        uroven = 1;
                    }

                    otazky.Add(new Otazka(textOtazky, moznosti, uroven));
                }

                return otazky;
            } else
            {
                return new List<Otazka>();
            }
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
