using Database;
using System;
using ReportController;
using ReportGenerator;
using ReportGenerator.TemplateEditor;
using RepostWinForms;
using TemplateDocEditor;

namespace DepartmentReportGenerator
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new WindowApplication();

            IReportView view = app.Form;

            TemplateFilesStorage fileStrorage = new WordTemplateFileStorage();
            IFileExtensionToExtensionConverter extensionConverter = new WordFileExtensionToExtensionConverter();

            var reportCreator = new ReportCreator(fileStrorage, extensionConverter);

            IReportModel model = new DatabaseReportModel();

            using (var controller = new ReportController.ReportController(model, view, reportCreator))
            {
                app.Start();
            }
        }
    }
}
