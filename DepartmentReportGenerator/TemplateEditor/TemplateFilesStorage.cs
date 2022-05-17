using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DepartmentReportGenerator.TemplateEditor
{
    public abstract class TemplateFilesStorage
    {
        // TODO: Перетащить в конфиг
        private static readonly ICollection<string> TemplateExtensions = new string[] { ".dotx", ".dot" };
        private static readonly string DirectoryWithTemplates = @"data";

        private IDictionary<string, string> _fileNamePathPairs;

        public ICollection<string> FileNames
        {
            get
            {
                _fileNamePathPairs ??= GetFileNamePathPairs();
                return _fileNamePathPairs.Keys;
            }
        }

        public IFile GetFile(string fileName)
        {
            return !_fileNamePathPairs.TryGetValue(fileName, out string filePath) ? null : GetFileHelper(filePath);
        }

        protected abstract IFile GetFileHelper(string relativeFilePath);

        private IDictionary<string, string> GetFileNamePathPairs()
        {
            return Directory.GetFiles(DirectoryWithTemplates)
                .Where(n => TemplateExtensions.Contains(Path.GetExtension(n)))
                .Select(n => (Path.GetFileName(n), n))
                .ToDictionary(k => k.Item1, i => i.Item2);
        }
    }
}