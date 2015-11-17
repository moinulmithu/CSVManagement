using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.ComponentModel;
//using LINQtoCSV;

namespace CSVManagement
{
    public class CsvReader : System.IDisposable
    {
        public CsvReader(string fileName)
            : this(new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
        }

        public CsvReader(Stream stream)
        {
            __reader = new StreamReader(stream, Encoding.GetEncoding("Shift_JIS"));
        }

        public System.Collections.IEnumerable RowEnumerator
        {
            get
            {
                if (null == __reader)
                    throw new System.ApplicationException("CSV File Not Found.");

                __rowno = 0;
                string sLine;
                string sNextLine;

                while (null != (sLine = __reader.ReadLine()))
                {
                    while (rexRunOnLine.IsMatch(sLine) && null != (sNextLine = __reader.ReadLine()))
                        sLine += "\n" + sNextLine;

                    __rowno++;
                    string[] values = rexCsvSplitter.Split(sLine);

                    for (int i = 0; i < values.Length; i++)
                        values[i] = Csv.Unescape(values[i]);

                    yield return values;
                }

                __reader.Close();
            }
        }

        public long RowIndex { get { return __rowno; } }

        public void Dispose()
        {
            if (null != __reader) __reader.Dispose();
        }

        //============================================


        private long __rowno = 0;
        private TextReader __reader;
        private static Regex rexCsvSplitter = new Regex(@",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))");
        private static Regex rexRunOnLine = new Regex(@"^[^""]*(?:""[^""]*""[^""]*)*""[^""]*$");
    }



    public static class Csv
    {
        public static string Escape(string s)
        {
            if (s.Contains(QUOTE))
                s = s.Replace(QUOTE, ESCAPED_QUOTE);

            if (s.IndexOfAny(CHARACTERS_THAT_MUST_BE_QUOTED) > -1)
                s = QUOTE + s + QUOTE;

            return s;
        }

        public static string Unescape(string s)
        {
            if (s.StartsWith(QUOTE) && s.EndsWith(QUOTE))
            {
                s = s.Substring(1, s.Length - 2);

                if (s.Contains(ESCAPED_QUOTE))
                    s = s.Replace(ESCAPED_QUOTE, QUOTE);
            }

            return s;
        }


        private const string QUOTE = "\"";
        private const string ESCAPED_QUOTE = "\"\"";
        private static char[] CHARACTERS_THAT_MUST_BE_QUOTED = { ',', '"', '\n' };
    }

    public static class List2DataTable
    {
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            DataTable table = new DataTable();
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {
                DataColumn dc = new DataColumn("Value");
                table.Columns.Add(dc);
                foreach (T item in data)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item;
                    table.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        try
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch (Exception ex)
                        {
                            row[prop.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }
    }

    public class ImportedFile
    {
        
        public string A1 { get; set; }
        public string A11 { get; set; }
        public string A12 { get; set; }
        public string A13 { get; set; }
        public string A14 { get; set; }
        public string A15 { get; set; }
        public string A16 { get; set; }
        public string A17 { get; set; }
        public string A18 { get; set; }
        public string A19 { get; set; }

        public string A2 { get; set; }
        public string A21 { get; set; }
        public string A22 { get; set; }
        public string A23 { get; set; }
        public string A24 { get; set; }
        public string A25 { get; set; }
        public string A26 { get; set; }
        public string A27 { get; set; }
        public string A28 { get; set; }
        public string A29 { get; set; }
        public string A3 { get; set; }
        public string A31 { get; set; }
        public string A32 { get; set; }
        public string A33 { get; set; }
        public string A34 { get; set; }
        public string A35 { get; set; }
        public string A36 { get; set; }
        public string A37 { get; set; }
        public string A38 { get; set; }
        public string A39 { get; set; }
        public string A4 { get; set; }
        public string A41 { get; set; }
        public string A42 { get; set; }
        public string A43 { get; set; }
        public string A44 { get; set; }
        public string A45 { get; set; }
        public string A46 { get; set; }
        public string A47 { get; set; }
        public string A48 { get; set; }
        public string A49 { get; set; }
        public string A5 { get; set; }
        public string A51 { get; set; }
        public string A52 { get; set; }
        public string A53 { get; set; }
        public string A54 { get; set; }
        public string A55 { get; set; }
        public string A56 { get; set; }
        public string A57 { get; set; }
        public string A58 { get; set; }
        public string A59 { get; set; }
        public string A6 { get; set; }
        public string A61 { get; set; }
        public string A62 { get; set; }
        public string A63 { get; set; }
        public string A64 { get; set; }
        public string A65 { get; set; }
        public string A66 { get; set; }
        public string A67 { get; set; }
        public string A68 { get; set; }
        public string A69 { get; set; }
        public string A7 { get; set; }
        public string A71 { get; set; }
        public string A72 { get; set; }
        public string A73 { get; set; }
        public string A74 { get; set; }
        public string A75 { get; set; }
        public string A76 { get; set; }
        public string A77 { get; set; }
        public string A78 { get; set; }
        public string A79 { get; set; }
        public string A8 { get; set; }
        public string A81 { get; set; }
        public string A82 { get; set; }
        public string A83 { get; set; }
        public string A84 { get; set; }
        public string A85 { get; set; }
        public string A86 { get; set; }
        public string A87 { get; set; }
        public string A88 { get; set; }
        public string A89 { get; set; }

    }


    public class ImportedFileForPersonalLoan
    {

        public string A1 { get; set; }
        public string A11 { get; set; }
        public string A12 { get; set; }
        public string A13 { get; set; }
        public string A14 { get; set; }
        public string A15 { get; set; }
        public string A16 { get; set; }
        public string A17 { get; set; }
        public string A18 { get; set; }
        public string A19 { get; set; }

        public string A2 { get; set; }
        public string A21 { get; set; }
        public string A22 { get; set; }
        public string A23 { get; set; }
        public string A24 { get; set; }
        public string A25 { get; set; }
        public string A26 { get; set; }
        public string A27 { get; set; }
        public string A28 { get; set; }
        public string A29 { get; set; }
        public string A3 { get; set; }
        public string A31 { get; set; }
        public string A32 { get; set; }
        public string A33 { get; set; }
        public string A34 { get; set; }
        public string A35 { get; set; }
        public string A36 { get; set; }
        public string A37 { get; set; }
        public string A38 { get; set; }
        public string A39 { get; set; }
        public string A4 { get; set; }
        public string A41 { get; set; }
        public string A42 { get; set; }
        public string A43 { get; set; }
        public string A44 { get; set; }
        public string A45 { get; set; }
        public string A46 { get; set; }
        public string A47 { get; set; }
        public string A48 { get; set; }
        public string A49 { get; set; }
        public string A5 { get; set; }
        public string A51 { get; set; }
        public string A52 { get; set; }
        public string A53 { get; set; }
        public string A54 { get; set; }
        public string A55 { get; set; }
        public string A56 { get; set; }
        public string A57 { get; set; }
        public string A58 { get; set; }
        public string A59 { get; set; }
        public string A6 { get; set; }
        public string A61 { get; set; }
        public string A62 { get; set; }
        public string A63 { get; set; }
        public string A64 { get; set; }
        public string A65 { get; set; }
        public string A66 { get; set; }
        public string A67 { get; set; }
        public string A68 { get; set; }
        public string A69 { get; set; }
        public string A7 { get; set; }
        public string A71 { get; set; }
        public string A72 { get; set; }
        public string A73 { get; set; }
       
      

    }
}
