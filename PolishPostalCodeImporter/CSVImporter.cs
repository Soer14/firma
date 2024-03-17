using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Common.Module.Tools
{
    public abstract class CSVImporter
    {

        public int rowCnt = 0;
        public Stopwatch watch;

        //public void Import()
        //{
        //    string[] pliki = PobierzPliki();

        //    foreach (string fileName in pliki)
        //    {
        //        if (File.Exists(fileName))
        //        {
        //            ImportujPlik(fileName);

        //        }
        //    }
        //}

        public void ImportujPlik(string fileName)
        {
            Console.WriteLine($"Import CSV file {fileName}");
            watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            using (CsvFileReader reader = new CsvFileReader(fileName, ','))
            {


                CsvRow row = new CsvRow();
                string lastValue = string.Empty;
                while (reader.ReadRow(row))
                {
                    int liczbaKolumn = row.Count;
                    //    var a = row[1];
                    //   Console.WriteLine(rowCnt);

                    if (rowCnt > 0)
                    {
                        ImportRow(row);

                    }
                    rowCnt++;
                }
            }
        }


        public void ImportujPlik(string fileName, char separator)
        {
            Console.WriteLine($"Import CSV file {fileName}");
            watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            using (CsvFileReader reader = new CsvFileReader(fileName, separator))
            {


                CsvRow row = new CsvRow();
                string lastValue = string.Empty;
                while (reader.ReadRow(row))
                {
                    int liczbaKolumn = row.Count;
                    //    var a = row[1];
                    //   Console.WriteLine(rowCnt);

                    if (rowCnt > 0)
                    {
                        ImportRow(row);

                    }
                    rowCnt++;
                }
            }
        }

        public abstract void ImportRow(CsvRow row);

        public decimal StringToDecimal(string text)
        {
            try
            {
                return decimal.Parse(text, new CultureInfo("pl-PL"));
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public static DateTime StringToDate(string text)
        {
            string datatext = text.Replace("\"", string.Empty);
            if (datatext != "NULL" && datatext != string.Empty)
            {
                try
                {
                    return DateTime.Parse(datatext);

                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not in the correct format.", datatext);
                    return DateTime.MinValue;
                }

            }
            return DateTime.MinValue;
        }

        public static Int64 StringToInt64(string text)
        {
            try
            {
                return Int64.Parse(text);
            }
            catch
            {
                return 0;
            }
        }


        public static int StringToInt(string text)
        {
            try
            {
                return int.Parse(text);
            }
            catch
            {
                return 0;
            }
        }


    }
}
