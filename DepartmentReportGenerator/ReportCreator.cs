using System;
using System.Collections.Generic;
using System.Linq;
using ReportGenerator.Exception;
using ReportGenerator.Generator;
using ReportGenerator.Model;
using ReportGenerator.TemplateEditor;
using ReportGenerator.Utils;

namespace ReportGenerator
{
    public class ReportCreator
    {
        private readonly TemplateFilesStorage _templateFiles;
        private ICollection<string> _templateNames;

        public ICollection<string> TemplateNames => _templateNames is null ? _templateNames = GetTemplateNames() : _templateNames;

        public ReportCreator(TemplateFilesStorage templateFiles)
        {
            _templateFiles = templateFiles;
        }

        public void Create(Document documentData, string templateName, string resultFilePath,
            TemplateEditor.Extension extension)
        {
            Generator.ReportGenerator reportGenerator = GetGeneratorByConfigName(templateName);
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

        private Generator.ReportGenerator GetGeneratorByConfigName(string templateName)
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