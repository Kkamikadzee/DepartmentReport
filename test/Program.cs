using System;
using System.Globalization;
using System.IO;
using TemplateDocEditor;

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

            using (var df = new DocFile(Path.Combine(Directory.GetCurrentDirectory(), "data", "template.dotx")))
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
                df.Tables[0].Cells[0, 0] = "KEK";
                df.Tables[0].Cells[0, 3] = "123ыыы";
                
                df.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "data", "result"), DocExtension.Doc);
                df.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "data", "result"), DocExtension.Default);
                df.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "data", "result"), DocExtension.Pdf);
            }
        }
    }
}