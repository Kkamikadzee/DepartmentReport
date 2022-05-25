using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IFileExtensionToExtensionConverter _extensionConverter;
        private ICollection<string> _templateNames;

        public ICollection<string> TemplateNames => _templateNames is null ? _templateNames = GetTemplateNames() : _templateNames;

        public ReportCreator(TemplateFilesStorage templateFiles, IFileExtensionToExtensionConverter extensionConverter)
        {
            _templateFiles = templateFiles;
            _extensionConverter = extensionConverter;
        }

        public void Create(Document documentData, string templateName, string resultFilePath)
        {
            ReportGenerator.TemplateEditor.Extension extension = _extensionConverter.Convert(Path.GetExtension(resultFilePath));

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
            switch (Config.Instance.KnownFilesTypes[templateName])
            {
                case "SingleTable":
                    return new SingleTableReportGenerator();
                default:
                    throw new UnknownGeneratorNameException(
                        $"Unknown generator name: '{Config.Instance.KnownFilesTypes[templateName]}'");
            }
        }
    }
}