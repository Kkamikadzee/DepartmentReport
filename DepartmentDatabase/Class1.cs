using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Linq;

namespace Database
{
    public static class Class1
    {
        public static void Test()
        {
            var models = new DatabaseReportModel();
            var students = models.Students;
            if (students.Count != 0)
            {
                var tmp1 = students.Where(s => s?.FirstName == "Петр").ToArray();
                Console.WriteLine(tmp1.FirstOrDefault()?.TopicOfFinalQualificationWork);
            }
            else
            {
                Console.WriteLine("Студентов нет");
            }
            


            ////string conString = String.Empty;
            ////switch (Path.GetExtension(path))
            ////{
            ////    case ".xls": //Excel 97-03.
            ////        conString = ConfigurationManager.ConnectionStrings["Excel03"].ConnectionString;
            ////        break;
            ////    case ".xlsx": //Excel 07 and above.
            ////        conString = ConfigurationManager.ConnectionStrings["Excel07"].ConnectionString;
            ////        break;
            ////}

            //string path = @"data/Dataset/data.xls";

            //string conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;

            //DataTable dt = new DataTable();
            //conString = string.Format(conString, path);

            //var tmp = File.Exists(path);

            //using (OleDbConnection connExcel = new OleDbConnection(conString))
            //{
            //    using (OleDbCommand cmdExcel = new OleDbCommand())
            //    {
            //        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
            //        {
            //            cmdExcel.Connection = connExcel;

            //            //Get the name of First Sheet.
            //            connExcel.Open();
            //            DataTable dtExcelSchema;
            //            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            //            connExcel.Close();

            //            //Read Data from First Sheet.
            //            connExcel.Open();
            //            cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
            //            odaExcel.SelectCommand = cmdExcel;
            //            odaExcel.Fill(dt);
            //            connExcel.Close();
            //        }
            //    }
            //}
        }
    }
}