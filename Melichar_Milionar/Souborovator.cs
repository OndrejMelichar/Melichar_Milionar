using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melichar_Milionar
{
    class Souborovator
    {

        public List<Otazka> NactiOtazky()
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
            }
            else
            {
                return new List<Otazka>();
            }
        }

        public void UlozHrace(Hrac hrac)
        {
            List<Hrac> statistiky = this.NactiHrace();

            statistiky.Add(hrac);

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string json = JsonConvert.SerializeObject(statistiky, settings);
            File.WriteAllText(@"statistiky.json", json);
        }

        public List<Hrac> NactiHrace()
        {
            if (File.Exists(@"statistiky.json"))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                string jsonFromFile = File.ReadAllText(@"statistiky.json");

                return JsonConvert.DeserializeObject<List<Hrac>>(jsonFromFile, settings);
            }

            return new List<Hrac>();
        }
    }
}
