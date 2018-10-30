﻿using OfficeOpenXml;
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

        private static void nactiOtazky()
        {
            List<Otazka> otazky = new List<Otazka>();

            if (File.Exists(@"D:\Ondřej Melichar\Moje data\škola\3. ročník\VAH\WPF\Melichar_Milionar\Melichar_Milionar\bin\Debug\otazky.xlsx"))
            {
                var package = new ExcelPackage(new FileInfo(@"D:\Ondřej Melichar\Moje data\škola\3. ročník\VAH\WPF\Melichar_Milionar\Melichar_Milionar\bin\Debug\otazky.xlsx"));
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Worksheet1"];
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
            }


            //return booksFromFile;
        }

    }
}
