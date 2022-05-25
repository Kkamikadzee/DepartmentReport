using System.Collections.Generic;
using System.IO;
using System.Linq;
using ReportGenerator.Utils;

namespace ReportGenerator.TemplateEditor
{
    public abstract class TemplateFilesStorage
    {
        private IDictionary<string, string> _fileNamePathPairs;

        public IDictionary<string, string> FileNamePathPairs
        {
            get
            {
                if(_fileNamePathPairs is null)
                {
                    _fileNamePathPairs = GetFileNamePathPairs();
                }

                return _fileNamePathPairs;
            }
        }

        public ICollection<string> FileNames
        {
            get
            {
                if (_fileNamePathPairs is null)
                {
                    _fileNamePathPairs = GetFileNamePathPairs();
                }
                return _fileNamePathPairs.Keys;
            }
        }

        public IFile GetFile(string fileName)
        {
            return !FileNamePathPairs.TryGetValue(fileName, out string filePath) ? null : GetFileHelper(filePath);
        }

        protected abstract IFile GetFileHelper(string relativeFilePath);

        private IDictionary<string, string> GetFileNamePathPairs()
        {
            return Directory.GetFiles(Config.Instance.DirectoryWithTemplates)
                .Where(n => Config.Instance.TemplateExtensions.Contains(Path.GetExtension(n)))
                .Select(n => (Path.GetFileName(n), n))
                .ToDictionary(k => k.Item1, i => i.Item2);
        }
    }
}