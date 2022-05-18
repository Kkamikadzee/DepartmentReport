﻿using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace DepartmentDatabase
{
    public static class Class1
    {
        public static void Test()
        {
            string path = @"data/Dataset/data.xls";

            //string conString = String.Empty;
            //switch (Path.GetExtension(path))
            //{
            //    case ".xls": //Excel 97-03.
            //        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
            //        break;
            //    case ".xlsx": //Excel 07 and above.
            //        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
            //        break;
            //}

            string conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;

            DataTable dt = new DataTable();
            conString = string.Format(conString, path);

            var tmp = File.Exists(path);

            using (OleDbConnection connExcel = new OleDbConnection(conString))
            {
                using (OleDbCommand cmdExcel = new OleDbCommand())
                {
                    using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                    {
                        cmdExcel.Connection = connExcel;

                        //Get the name of First Sheet.
                        connExcel.Open();
                        DataTable dtExcelSchema;
                        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        connExcel.Close();

                        //Read Data from First Sheet.
                        connExcel.Open();
                        cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                        odaExcel.SelectCommand = cmdExcel;
                        odaExcel.Fill(dt);
                        connExcel.Close();
                    }
                }
            }

        }
    }
}
