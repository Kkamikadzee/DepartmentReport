using ReportGenerator.TemplateEditor;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateDocEditor
{
    public class WordFileExtensionToExtensionConverter : IFileExtensionToExtensionConverter
    {
        public Extension Convert(string extension)
        {
            var _extension = extension.TrimStart('.');
            switch(_extension)
            {
                case "docx":
                    return Extension.Default;
                case "doc":
                    return Extension.Doc;
                case "pdf":
                    return Extension.Pdf;
                default:
                    return Extension.Pdf;
            }
        }
    }
}
