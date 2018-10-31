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
            while (true)
            {
                List<Otazka> otazkyPodleUrovne = this.vratOtazkyPodleUrovne(uroven);

                if (otazkyPodleUrovne.Count > 0)
                {
                    Otazka otazka = otazkyPodleUrovne[this.random.Next(otazkyPodleUrovne.Count)];

                    if (otazka.Uroven == uroven)
                    {
                        return otazka;
                    }
                } else
                {
                    return null;
                }
            }
        }

        private List<Otazka> vratOtazkyPodleUrovne(int uroven)
        {
            List<Otazka> otazkyPodleUrovne = new List<Otazka>();

            foreach (Otazka otazka in this.otazky)
            {
                if (otazka.Uroven == uroven)
                {
                    otazkyPodleUrovne.Add(otazka);
                }
            }

            return otazkyPodleUrovne;
        }

    }
}
