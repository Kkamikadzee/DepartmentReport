using System;
using System.Globalization;
using System.IO;
using DepartmentReportGenerator.DocEditor;
using TemplateDocEditor;
using File = TemplateDocEditor.File;

namespace test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // TemplateDocEditor.TemplateDocEditor dr = null;
            //
            // try
            // {
            //     dr = new TemplateDocEditor.TemplateDocEditor();
            //     // dr.DoSomething();
            //     dr.Search();
            // }
            // finally
            // {
            //     dr?.Dispose();
            // }

            using (var df = new File(Path.Combine(Directory.GetCurrentDirectory(), "data", "template.dotx")))
            {
                df.Fields["CurrentData"].Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                df.Fields["Department"].Text = "Какой-то не очень длинный текст";
                df.Fields["TextHeader"].Text = "Какой-то очень длинный текст текст текст текст текст текст текст текст " +
                                               "текст текст текст текст текст текст текст текст текст текст текст текст" +
                                               "текст текст текст текст текст текст текст текст текст текст текст текст" +
                                               "текст текст текст текст текст текст текст текст текст текст текст текст" +
                                               "текст текст текст текст текст текст текст текст текст текст текст текст" +
                                               "текст текст текст текст текст текст текст текст текст текст текст текст" +
                                               "текст текст текст текст текст текст текст текст текст текст текст текст" +
                                               "текст текст текст текст текст текст текст текст текст текст текст текст" +
                                               "текст текст текст текст текст текст текст текст текст текст текст текст" +
                                               "текст текст текст текст текст текст текст текст текст текст текст текст";
                
                df.Tables[0].AddRow();
                df.Tables[0].Cells[0, 0] = "Ячейка 0 0";
                df.Tables[0].Cells[0, 3] = "Ячейка 0 3";

                df.Tables[0].AddRow();
                df.Tables[0].Cells[1, 2] = "Ячейка 1 2";
                df.Tables[0].Cells[1, 4] = "Ячейка 1 4";
                
                df.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "data", "result"), Extension.Doc);
                df.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "data", "result"), Extension.Default);
                df.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "data", "result"), Extension.Pdf);
            }
        }
    }
}