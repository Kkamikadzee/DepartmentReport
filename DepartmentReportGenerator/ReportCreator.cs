using System;
using System.Collections.Generic;
using System.Linq;
using DepartmentReportGenerator.Exception;
using DepartmentReportGenerator.Generator;
using DepartmentReportGenerator.Model;
using DepartmentReportGenerator.TemplateEditor;
using DepartmentReportGenerator.Utils;

namespace DepartmentReportGenerator
{
    public class ReportCreator
    {
        private readonly TemplateFilesStorage _templateFiles;
        private ICollection<string> _templateNames;

        public ICollection<string> TemplateNames => _templateNames ??= GetTemplateNames();

        public ReportCreator(TemplateFilesStorage templateFiles)
        {
            _templateFiles = templateFiles;
        }

        public void Create(Document documentData, string templateName, string resultFilePath,
            TemplateEditor.Extension extension)
        {
            ReportGenerator reportGenerator = GetGeneratorByConfigName(templateName);
            using (IFile file = _templateFiles.GetFile(templateName))
            {
                try
                {
                    reportGenerator.Generate(file, documentData);
                }
                catch (System.Exception e)
                {
                    throw new ReportCreationException(
                        $"An error occurred while generating the report: '{e.Message}' \n Details in inner exception.",
                        e);
                }

                try
                {
                    file.SaveAs(resultFilePath, extension);
                }
                catch (System.Exception e)
                {
                    throw new ReportCreationException(
                        $"An error occurred while saving the report: '{e.Message}' \n Details in inner exception.",
                        e);
                }
            }
        }

        private ICollection<string> GetTemplateNames()
        {
            return Config.Instance.KnownFiles.Intersect(_templateFiles.FileNames).ToArray();
        }

        private ReportGenerator GetGeneratorByConfigName(string templateName)
        {
            switch (Config.Instance[templateName])
            {
                case "SingleTable":
                    return new SingleTableReportGenerator();
                default:
                    throw new UnknownGeneratorNameException(
                        $"Unknown generator name: '{Config.Instance[templateName]}'");
            }
        }
    }
}