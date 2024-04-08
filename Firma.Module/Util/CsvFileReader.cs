using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.Util
{
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }

    /// <summary>
    /// Class to read data from a CSV file
    /// </summary>
    public class CsvFileReader : StreamReader
    {
        private readonly char separator = ';';

        public CsvFileReader(Stream stream, char sep = ';') : base(stream)
        {
            separator = sep;
        }

        public CsvFileReader(string filename, char sep = ';') : base(filename)
        {
            separator = sep;
        }

        /// <summary>
        /// Reads a row of data from a CSV file
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (string.IsNullOrEmpty(row.LineText)) return false;

            int pos = 0;
            int rows = 0;

            while (pos < row.LineText.Length)
            {
                string value;
                if (row.LineText[pos] == '"' || row.LineText[pos] == '\'')
                {
                    pos++;
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        if (row.LineText[pos] == '"' || row.LineText[pos] == '\'')
                        {
                            pos++;
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"' || row.LineText[pos] == '\'')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != separator) pos++;
                    value = row.LineText.Substring(start, pos - start);
                }

                if (rows < row.Count) row[rows] = value;
                else row.Add(value);
                rows++;

                while (pos < row.LineText.Length && row.LineText[pos] != separator) pos++;
                if (pos < row.LineText.Length) pos++;
            }

            while (row.Count > rows) row.RemoveAt(rows);
            return (row.Count > 0);
        }
    }
}
