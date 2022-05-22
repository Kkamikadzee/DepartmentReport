using ReportGenerator.TemplateEditor;
using System.IO;

namespace TemplateDocEditor
{
    public class WordTemplateFileStorage : TemplateFilesStorage
    {
        protected override IFile GetFileHelper(string relativeFilePath)
        {
            return new File(Path.Combine(Directory.GetCurrentDirectory(), relativeFilePath));
        }
    }
}
