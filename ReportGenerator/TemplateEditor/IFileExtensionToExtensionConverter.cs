using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.TemplateEditor
{
    public interface IFileExtensionToExtensionConverter
    {
        Extension Convert(string extension);
    }
}
