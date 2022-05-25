using System;
using System.Collections.Generic;
using System.Text;
using ReportGenerator;
using ReportController.Utils;
using ReportGenerator.Model;
using ReportGenerator.TemplateEditor;
using System.IO;
using System.Threading.Tasks;

namespace ReportController
{
    public class ReportController : IDisposable
    {
        private readonly IReportModel _model;
        private readonly IReportView _view;
        private readonly ReportCreator _reportGenerator;

        public ReportController(IReportModel model, IReportView view, ReportCreator reportCreator)
        {
            _model = model;
            _view = view;
            _reportGenerator = reportCreator;

            _view.GenerateDocument += GenerateDocument;

            InitializeView();
        }

        public void Dispose()
        {
            _view.GenerateDocument -= GenerateDocument;
        }

        private void InitializeView()
        {
            _view.Departments = _model.Departments;
            _view.FqwTemplateFiles = Config.Instance.FqwTemplateFiles;
            _view.PracticeTemplateFiles = Config.Instance.PracticeTemplateFiles;
            _view.Teachers = _model.Teachers;

            _view.PracticeKind = Config.Instance.PracticeKinds;
            _view.PracticeType = Config.Instance.PracticeTypes;
        }

        private async void GenerateDocument(Document document, string templateName, string resultFilePath)
        {
            string result = await Task.Run(() =>
            {
                try
                {
                    _reportGenerator.Create(document, templateName, resultFilePath);

                    return $"Отчёт {Path.GetFileName(templateName)} создан.";
                }
                catch (Exception ex)
                {
                    return $"Ошибка: {ex.Message}";
                }
            });

            _view.SetStatus(result);
        }
    }
}
