using CSVManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSVManagementWithConsole
{

    class Program
    {
        private static string batchFilename { get; set; }
        private static string batchFilePath { get; set; }
        private static int batchType { get; set; }
        private static string csvFilePath { get; set; }
        private static string csvFileName { get; set; }

        public static List<ImportedFile> importedList = new List<ImportedFile>();
        public static List<ImportedFile> CheckimportedList = new List<ImportedFile>();
        public static ImportedFile entity = new ImportedFile();

        public static ImportedFileForPersonalLoan PersonalLoanentity = new ImportedFileForPersonalLoan();
        public static List<ImportedFileForPersonalLoan> CheckPersonalFileList = new List<ImportedFileForPersonalLoan>();
        public static List<ImportedFileForPersonalLoan> PersonalLoanImportedList = new List<ImportedFileForPersonalLoan>();
        static void Main(string[] args)
        {
            //CheckimportedList = new List<ImportedFile>();
            //Import();
            //ExportCSV();

            CheckPersonalFileList = new List<ImportedFileForPersonalLoan>();
            ImportPersonalLoan();
            ExportPersonalLoan();
            
        }

        //===============Import Corporate_All======================
        private static void Import()
        {
            //DataTable dt = new DataTable();            
            //StreamReader srTxt = new StreamReader("Count.txt");
            //personal_loan_form
            using (CsvReader reader = new CsvReader("C:\\CSV\\Source\\corporate_all.csv"))
            {
                foreach (string[] values in reader.RowEnumerator)
                {

                    ImportedFile entity = new ImportedFile();
                    #region Columns
                    if (values[0].ToString() == "Serial")
                    {
                        entity.A1 = values[0].ToString();
                    }
                    else
                    {
                        string strd = values[0].ToString();
                        NumberStyles styles;
                        styles = NumberStyles.AllowExponent | NumberStyles.Number;
                        double dbl = Double.Parse(strd, styles);
                        entity.A1 = dbl.ToString();
                    }
                    entity.A11 = values[1].ToString();
                    entity.A12 = values[2].ToString();
                    entity.A13 = values[3].ToString();
                    entity.A14 = values[4].ToString();
                    entity.A15 = values[5].ToString();
                    entity.A16 = values[6].ToString();
                    entity.A17 = values[7].ToString();
                    entity.A18 = values[8].ToString();
                    entity.A19 = values[9].ToString();

                    entity.A2 =  values[10].ToString();
                    entity.A21 = values[11].ToString();
                    entity.A22 = values[12].ToString();
                    entity.A23 = values[13].ToString();
                    entity.A24 = values[14].ToString();
                    entity.A25 = values[15].ToString();
                    entity.A26 = values[16].ToString();
                    entity.A27 = values[17].ToString();
                    entity.A28 = values[18].ToString();
                    entity.A29 = values[19].ToString();
                    entity.A3  =  values[20].ToString();
                    entity.A31 = values[21].ToString();
                    entity.A32 = values[22].ToString();
                    entity.A33 = values[23].ToString();
                    entity.A34 = values[24].ToString();
                    entity.A35 = values[25].ToString();
                    entity.A36 = values[26].ToString();
                    entity.A37 = values[27].ToString();
                    entity.A38 = values[28].ToString();
                    entity.A39 = values[29].ToString();
                    entity.A4 =  values[30].ToString();
                    entity.A41 = values[31].ToString();
                    entity.A42 = values[32].ToString();
                    entity.A43 = values[33].ToString();
                    entity.A44 = values[34].ToString();
                    entity.A45 = values[35].ToString();
                    entity.A46 = values[36].ToString();
                    entity.A47 = values[37].ToString();
                    entity.A48 = values[38].ToString();
                    entity.A49 = values[39].ToString();
                    entity.A5 =  values[40].ToString();
                    entity.A51 = values[41].ToString();
                    entity.A52 = values[42].ToString();
                    entity.A53 = values[43].ToString();
                    entity.A54 = values[44].ToString();
                    entity.A55 = values[45].ToString();
                    entity.A56 = values[46].ToString();
                    entity.A57 = values[47].ToString();
                    entity.A58 = values[48].ToString();
                    entity.A59 = values[49].ToString();
                    entity.A6 =  values[50].ToString();
                    entity.A61 = values[51].ToString();
                    entity.A62 = values[52].ToString();
                    entity.A63 = values[53].ToString();
                    entity.A64 = values[54].ToString();
                    entity.A65 = values[55].ToString();
                    entity.A66 = values[56].ToString();
                    entity.A67 = values[57].ToString();
                    entity.A68 = values[58].ToString();
                    entity.A69 = values[59].ToString();
                    entity.A7 = values[60].ToString();
                    entity.A71 = values[61].ToString();
                    entity.A72 = values[62].ToString();
                    entity.A73 = values[63].ToString();
                    entity.A74 = values[64].ToString();
                    entity.A75 = values[65].ToString();
                    entity.A76 = values[66].ToString();
                    entity.A77 = values[67].ToString();
                    entity.A78 = values[68].ToString();
                    entity.A79 = values[69].ToString();
                    entity.A8 = values[70].ToString();
                    entity.A81 = values[71].ToString();
                    entity.A82 = values[72].ToString();
                    entity.A83 = values[73].ToString();
                    entity.A84 = values[74].ToString();
                    entity.A85 = values[75].ToString();
                    entity.A86 = values[76].ToString();
                    entity.A87 = values[77].ToString();
                    #endregion

                    importedList.Add(entity);
                }


            }

            
        }

        //=========================Export Corporate_All========================
        
        private static void ExportCSV()
        {
            StreamReader readCount = new StreamReader("C:\\CSV\\Count.txt");
            int PreviousCount = 0;
            string lineToText = readCount.ReadToEnd();
            readCount.Close();
            PreviousCount = Convert.ToInt32(lineToText);

            if (importedList.Count() < PreviousCount)
                PreviousCount = 0;


            string FileToPath = "C:\\CSV\\Done\\ExportedData";
            DataTable dt = new DataTable();
            dt = List2DataTable.ToDataTable(importedList);

            if (importedList.Count() > 0)
            {
                StreamWriter sw = new StreamWriter(FileToPath  + DateTime.Now.ToString("-yyyy-MM-dd-HH-mm") + ".csv", false, Encoding.GetEncoding("Shift_JIS"));
                Type itemType = typeof(ImportedFile);

                var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                for (int i = 0; i < importedList.Count(); i++)
                {
                    if (i > PreviousCount)
                    {
                        #region Columns
                        ImportedFile entity = new ImportedFile();
                        entity.A1 = importedList[i].A1;
                        entity.A11 = importedList[i].A11;
                        entity.A12 = importedList[i].A12;
                        entity.A13 = importedList[i].A13;
                        entity.A14 = importedList[i].A14;
                        entity.A15 = importedList[i].A15;
                        entity.A16 = importedList[i].A16;
                        entity.A17 = importedList[i].A17;
                        entity.A18 = importedList[i].A18;
                        entity.A19 = importedList[i].A19;
                        entity.A2 = importedList[i].A2;
                        entity.A21 = importedList[i].A21;
                        entity.A22 = importedList[i].A22;
                        entity.A23 = importedList[i].A23;
                        entity.A24 = importedList[i].A24;
                        entity.A25 = importedList[i].A25;
                        entity.A26 = importedList[i].A26;
                        entity.A27 = importedList[i].A27;
                        entity.A28 = importedList[i].A28;
                        entity.A29 = importedList[i].A29;
                        entity.A3 = importedList[i].A3;
                        entity.A31 = importedList[i].A31;
                        entity.A32 = importedList[i].A32;
                        entity.A33 = importedList[i].A33;
                        entity.A34 = importedList[i].A34;
                        entity.A35 = importedList[i].A35;
                        entity.A36 = importedList[i].A36;
                        entity.A37 = importedList[i].A37;
                        entity.A38 = importedList[i].A38;
                        entity.A39 = importedList[i].A39;
                        entity.A4 = importedList[i].A4;
                        entity.A41 = importedList[i].A41;
                        entity.A42 = importedList[i].A42;
                        entity.A43 = importedList[i].A43;
                        entity.A44 = importedList[i].A44;
                        entity.A45 = importedList[i].A45;
                        entity.A46 = importedList[i].A46;
                        entity.A47 = importedList[i].A47;
                        entity.A48 = importedList[i].A48;
                        entity.A49 = importedList[i].A49;
                        entity.A5 = importedList[i].A5;
                        entity.A51 = importedList[i].A51;
                        entity.A52 = importedList[i].A52;
                        entity.A53 = importedList[i].A53;
                        entity.A54 = importedList[i].A54;
                        entity.A55 = importedList[i].A55;
                        entity.A56 = importedList[i].A56;
                        entity.A57 = importedList[i].A57;
                        entity.A58 = importedList[i].A58;
                        entity.A59 = importedList[i].A59;
                        entity.A6 = importedList[i].A6;
                        entity.A61 = importedList[i].A61;
                        entity.A62 = importedList[i].A62;
                        entity.A63 = importedList[i].A63;
                        entity.A64 = importedList[i].A64;
                        entity.A65 = importedList[i].A65;
                        entity.A66 = importedList[i].A66;
                        entity.A67 = importedList[i].A67;
                        entity.A68 = importedList[i].A68;
                        entity.A69 = importedList[i].A69;
                        entity.A7 = importedList[i].A7;
                        entity.A71 = importedList[i].A71;
                        entity.A72 = importedList[i].A72;
                        entity.A73 = importedList[i].A73;
                        entity.A74 = importedList[i].A74;
                        entity.A75 = importedList[i].A75;
                        entity.A76 = importedList[i].A76;
                        entity.A77 = importedList[i].A77;
                        entity.A78 = importedList[i].A78;
                        entity.A79 = importedList[i].A79;
                        entity.A8 = importedList[i].A8;
                        entity.A81 = importedList[i].A81;
                        entity.A82 = importedList[i].A82;
                        entity.A83 = importedList[i].A83;
                        entity.A84 = importedList[i].A84;
                        entity.A85 = importedList[i].A85;
                        entity.A86 = importedList[i].A86;
                        entity.A87 = importedList[i].A87;

                        CheckimportedList.Add(entity);
                        #endregion
                    }
                }
                foreach (var item in CheckimportedList)
                {

                    sw.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));

                }
                sw.Close();
                int CurrentCount = importedList.Count;
                StreamWriter WriteCount = new StreamWriter("C:\\CSV\\Count.txt");
                WriteCount.Write(CurrentCount);
                WriteCount.Close();

                StreamWriter swT = new StreamWriter("C:\\CSV\\Count.log", true);
                var StratWith = CheckimportedList[PreviousCount + 1].A1;
                var EndWith = CheckimportedList[CheckimportedList.Count() - 1].A1;

                string serial = "Export From" + StratWith + "To" + EndWith + " " + "Exported Date : " + System.DateTime.Now;

                swT.Write(serial);
                swT.Close();
            }
            else
            {
                string FileBlankPath = "ExportedFile";
                StreamWriter sw = new StreamWriter(FileBlankPath + ".csv", false, Encoding.GetEncoding("Shift_JIS"));
                sw.Write("", "", "");
                sw.Close();
            }

            Console.WriteLine("Exported Successfully");
            

            //Thread.Sleep(3000);
            File.Move("C:\\CSV\\Source\\corporate_all.csv", @"C:\\CSV\\Archive\\" + DateTime.Now.ToString("-yyyy-MM-dd-HH-mm") + ".csv");
           // File.Move(csvFilePath + csvFileName + ".csv", csvFilePath + @"Done\" + csvFileName + DateTime.Now.ToString("-yyyy-MM-dd-HH-mm") + ".csv");
        }
        //=======================Import Personal Loan==========================
        private static void ImportPersonalLoan()
        {
            using (CsvReader reader = new CsvReader("C:\\CSV\\Source\\personal_loan_form.csv"))
            {
                foreach (string[] values in reader.RowEnumerator)
                {

                    ImportedFileForPersonalLoan PersonalLoanentity = new ImportedFileForPersonalLoan();
                    #region Columns
                    if (values[0].ToString() == "Serial")
                    {
                        PersonalLoanentity.A1 = values[0].ToString();
                    }
                    else
                    {
                        string strd = values[0].ToString();
                        NumberStyles styles;
                        styles = NumberStyles.AllowExponent | NumberStyles.Number;
                        double dbl = Double.Parse(strd, styles);
                        PersonalLoanentity.A1 = dbl.ToString();
                        
                    }
                    //PersonalLoanentity.A1 = values[0].ToString();
                    PersonalLoanentity.A11 = values[1].ToString();
                    PersonalLoanentity.A12 = values[2].ToString();
                    PersonalLoanentity.A13 = values[3].ToString();
                    PersonalLoanentity.A14 = values[4].ToString();
                    PersonalLoanentity.A15 = values[5].ToString();
                    PersonalLoanentity.A16 = values[6].ToString();
                    PersonalLoanentity.A17 = values[7].ToString();
                    PersonalLoanentity.A18 = values[8].ToString();
                    PersonalLoanentity.A19 = values[9].ToString();

                    PersonalLoanentity.A2 = values[10].ToString();
                    PersonalLoanentity.A21 = values[11].ToString();
                    PersonalLoanentity.A22 = values[12].ToString();
                    PersonalLoanentity.A23 = values[13].ToString();
                    PersonalLoanentity.A24 = values[14].ToString();
                    PersonalLoanentity.A25 = values[15].ToString();
                    PersonalLoanentity.A26 = values[16].ToString();
                    PersonalLoanentity.A27 = values[17].ToString();
                    PersonalLoanentity.A28 = values[18].ToString();
                    PersonalLoanentity.A29 = values[19].ToString();
                    PersonalLoanentity.A3 = values[20].ToString();
                    PersonalLoanentity.A31 = values[21].ToString();
                    PersonalLoanentity.A32 = values[22].ToString();
                    PersonalLoanentity.A33 = values[23].ToString();
                    PersonalLoanentity.A34 = values[24].ToString();
                    PersonalLoanentity.A35 = values[25].ToString();
                    PersonalLoanentity.A36 = values[26].ToString();
                    PersonalLoanentity.A37 = values[27].ToString();
                    PersonalLoanentity.A38 = values[28].ToString();
                    PersonalLoanentity.A39 = values[29].ToString();
                    PersonalLoanentity.A4 = values[30].ToString();
                    PersonalLoanentity.A41 = values[31].ToString();
                    PersonalLoanentity.A42 = values[32].ToString();
                    PersonalLoanentity.A43 = values[33].ToString();
                    PersonalLoanentity.A44 = values[34].ToString();
                    PersonalLoanentity.A45 = values[35].ToString();
                    PersonalLoanentity.A46 = values[36].ToString();
                    PersonalLoanentity.A47 = values[37].ToString();
                    PersonalLoanentity.A48 = values[38].ToString();
                    PersonalLoanentity.A49 = values[39].ToString();
                    PersonalLoanentity.A5 = values[40].ToString();
                    PersonalLoanentity.A51 = values[41].ToString();
                    PersonalLoanentity.A52 = values[42].ToString();
                    PersonalLoanentity.A53 = values[43].ToString();
                    PersonalLoanentity.A54 = values[44].ToString();
                    PersonalLoanentity.A55 = values[45].ToString();
                    PersonalLoanentity.A56 = values[46].ToString();
                    PersonalLoanentity.A57 = values[47].ToString();
                    PersonalLoanentity.A58 = values[48].ToString();
                    PersonalLoanentity.A59 = values[49].ToString();
                    PersonalLoanentity.A6 = values[50].ToString();
                    PersonalLoanentity.A61 = values[51].ToString();
                    PersonalLoanentity.A62 = values[52].ToString();
                    PersonalLoanentity.A63 = values[53].ToString();
                    PersonalLoanentity.A64 = values[54].ToString();
                    PersonalLoanentity.A65 = values[55].ToString();
                    PersonalLoanentity.A66 = values[56].ToString();
                    PersonalLoanentity.A67 = values[57].ToString();
                    PersonalLoanentity.A68 = values[58].ToString();
                    PersonalLoanentity.A69 = values[59].ToString();
                    PersonalLoanentity.A7 = values[60].ToString();
                    PersonalLoanentity.A71 = values[61].ToString();
                    PersonalLoanentity.A72 = values[62].ToString();
                    PersonalLoanentity.A73 = values[63].ToString();

                    #endregion

                    PersonalLoanImportedList.Add(PersonalLoanentity);

                }
                



            }

            
        }
        //================Export Personal Loan=======================

        private static void ExportPersonalLoan()
        {
            StreamReader readCount = new StreamReader("C:\\CSV\\Count2.txt");
            int PreviousCount = 0;
            string lineToText = readCount.ReadToEnd();
            readCount.Close();
            PreviousCount = Convert.ToInt32(lineToText);

            if (PersonalLoanImportedList.Count() < PreviousCount)
                PreviousCount = 0;


            string FileToPath = "C:\\CSV\\Done\\PersonalLoanExportedData";
            DataTable dt = new DataTable();
            dt = List2DataTable.ToDataTable(PersonalLoanImportedList);

            if (PersonalLoanImportedList.Count() > 0)
            {
                StreamWriter sw = new StreamWriter(FileToPath +  DateTime.Now.ToString("-yyyy-MM-dd-HH-mm") + ".csv", false, Encoding.GetEncoding("Shift_JIS"));
                Type itemType = typeof(ImportedFileForPersonalLoan);

                var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                for (int i = 0; i < PersonalLoanImportedList.Count(); i++)
                {
                    if (i > PreviousCount)
                    {
                        #region Columns
                        ImportedFileForPersonalLoan PersonalLoanentity = new ImportedFileForPersonalLoan();
                        PersonalLoanentity.A1 = PersonalLoanImportedList[i].A1;
                        PersonalLoanentity.A11 = PersonalLoanImportedList[i].A11;
                        PersonalLoanentity.A12 = PersonalLoanImportedList[i].A12;
                        PersonalLoanentity.A13 = PersonalLoanImportedList[i].A13;
                        PersonalLoanentity.A14 = PersonalLoanImportedList[i].A14;
                        PersonalLoanentity.A15 = PersonalLoanImportedList[i].A15;
                        PersonalLoanentity.A16 = PersonalLoanImportedList[i].A16;
                        PersonalLoanentity.A17 = PersonalLoanImportedList[i].A17;
                        PersonalLoanentity.A18 = PersonalLoanImportedList[i].A18;
                        PersonalLoanentity.A19 = PersonalLoanImportedList[i].A19;
                        PersonalLoanentity.A2 = PersonalLoanImportedList[i].A2;
                        PersonalLoanentity.A21 = PersonalLoanImportedList[i].A21;
                        PersonalLoanentity.A22 = PersonalLoanImportedList[i].A22;
                        PersonalLoanentity.A23 = PersonalLoanImportedList[i].A23;
                        PersonalLoanentity.A24 = PersonalLoanImportedList[i].A24;
                        PersonalLoanentity.A25 = PersonalLoanImportedList[i].A25;
                        PersonalLoanentity.A26 = PersonalLoanImportedList[i].A26;
                        PersonalLoanentity.A27 = PersonalLoanImportedList[i].A27;
                        PersonalLoanentity.A28 = PersonalLoanImportedList[i].A28;
                        PersonalLoanentity.A29 = PersonalLoanImportedList[i].A29;
                        PersonalLoanentity.A3 = PersonalLoanImportedList[i].A3;
                        PersonalLoanentity.A31 = PersonalLoanImportedList[i].A31;
                        PersonalLoanentity.A32 = PersonalLoanImportedList[i].A32;
                        PersonalLoanentity.A33 = PersonalLoanImportedList[i].A33;
                        PersonalLoanentity.A34 = PersonalLoanImportedList[i].A34;
                        PersonalLoanentity.A35 = PersonalLoanImportedList[i].A35;
                        PersonalLoanentity.A36 = PersonalLoanImportedList[i].A36;
                        PersonalLoanentity.A37 = PersonalLoanImportedList[i].A37;
                        PersonalLoanentity.A38 = PersonalLoanImportedList[i].A38;
                        PersonalLoanentity.A39 = PersonalLoanImportedList[i].A39;
                        PersonalLoanentity.A4 = PersonalLoanImportedList[i].A4;
                        PersonalLoanentity.A41 = PersonalLoanImportedList[i].A41;
                        PersonalLoanentity.A42 = PersonalLoanImportedList[i].A42;
                        PersonalLoanentity.A43 = PersonalLoanImportedList[i].A43;
                        PersonalLoanentity.A44 = PersonalLoanImportedList[i].A44;
                        PersonalLoanentity.A45 = PersonalLoanImportedList[i].A45;
                        PersonalLoanentity.A46 = PersonalLoanImportedList[i].A46;
                        PersonalLoanentity.A47 = PersonalLoanImportedList[i].A47;
                        PersonalLoanentity.A48 = PersonalLoanImportedList[i].A48;
                        PersonalLoanentity.A49 = PersonalLoanImportedList[i].A49;
                        PersonalLoanentity.A5 = PersonalLoanImportedList[i].A5;
                        PersonalLoanentity.A51 = PersonalLoanImportedList[i].A51;
                        PersonalLoanentity.A52 = PersonalLoanImportedList[i].A52;
                        PersonalLoanentity.A53 = PersonalLoanImportedList[i].A53;
                        PersonalLoanentity.A54 = PersonalLoanImportedList[i].A54;
                        PersonalLoanentity.A55 = PersonalLoanImportedList[i].A55;
                        PersonalLoanentity.A56 = PersonalLoanImportedList[i].A56;
                        PersonalLoanentity.A57 = PersonalLoanImportedList[i].A57;
                        PersonalLoanentity.A58 = PersonalLoanImportedList[i].A58;
                        PersonalLoanentity.A59 = PersonalLoanImportedList[i].A59;
                        PersonalLoanentity.A6 = PersonalLoanImportedList[i].A6;
                        PersonalLoanentity.A61 = PersonalLoanImportedList[i].A61;
                        PersonalLoanentity.A62 = PersonalLoanImportedList[i].A62;
                        PersonalLoanentity.A63 = PersonalLoanImportedList[i].A63;
                        PersonalLoanentity.A64 = PersonalLoanImportedList[i].A64;
                        PersonalLoanentity.A65 = PersonalLoanImportedList[i].A65;
                        PersonalLoanentity.A66 = PersonalLoanImportedList[i].A66;
                        PersonalLoanentity.A67 = PersonalLoanImportedList[i].A67;
                        PersonalLoanentity.A68 = PersonalLoanImportedList[i].A68;
                        PersonalLoanentity.A69 = PersonalLoanImportedList[i].A69;
                        PersonalLoanentity.A7 = PersonalLoanImportedList[i].A7;
                        PersonalLoanentity.A71 = PersonalLoanImportedList[i].A71;
                        PersonalLoanentity.A72 = PersonalLoanImportedList[i].A72;
                        PersonalLoanentity.A73 = PersonalLoanImportedList[i].A73;
                        

                        CheckPersonalFileList.Add(PersonalLoanentity);
                        #endregion
                    }
                }
                foreach (var item in CheckPersonalFileList)
                {

                    sw.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                    //Console.WriteLine(item.A1);
                   

                }
                //Console.ReadKey();
                sw.Close();
                int CurrentCount = PersonalLoanImportedList.Count;
                StreamWriter WriteCount = new StreamWriter("C:\\CSV\\Count2.txt");
                WriteCount.Write(CurrentCount);
                WriteCount.Close();

                StreamWriter swT = new StreamWriter("C:\\CSV\\Count2.log", true);
                var StratWith = CheckPersonalFileList[PreviousCount + 1].A1;
                var EndWith = CheckPersonalFileList[CheckPersonalFileList.Count() - 1].A1;

                string serial = "Export From" + StratWith + "To" + EndWith + " " + "Exported Date : " + System.DateTime.Now;

                swT.Write(serial);
                swT.Close();
            }
            else
            {
                string FileBlankPath = "ExportedFile";
                StreamWriter sw = new StreamWriter(FileBlankPath + ".csv", false, Encoding.GetEncoding("Shift_JIS"));
                sw.Write("", "", "");
                sw.Close();
            }

            Console.WriteLine("Data Exported Successfully");
            File.Move("C:\\CSV\\Source\\personal_loan_form.csv", @"C:\\CSV\\Archive\\" + "Personal Loan" + DateTime.Now.ToString("-yyyy-MM-dd-HH-mm") + ".csv");
            Console.WriteLine("Export Successful");
                
        }
    }
}
