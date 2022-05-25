using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace ReportController.Utils
{
    public sealed class Config
    {
        private static readonly Lazy<Config> LazyInstance = new Lazy<Config>(() => new Config());

        public static Config Instance => LazyInstance.Value;

        private readonly ICollection<string> _fqwTemplateFiles;
        private readonly ICollection<string> _practiceTemplateFiles;

        private readonly ICollection<string> _practiceKinds;
        private readonly ICollection<string> _practiceTypes;

        public ICollection<string> FqwTemplateFiles => _fqwTemplateFiles;
        public ICollection<string> PracticeTemplateFiles => _practiceTemplateFiles;

        public ICollection<string> PracticeKinds => _practiceKinds;
        public ICollection<string> PracticeTypes => _practiceTypes;

        private Config()
        {
            NameValueCollection configTemplates = ConfigurationManager.GetSection("reportControllerSettings/templateFilesType") as NameValueCollection;
            _fqwTemplateFiles = configTemplates.AllKeys.Where(k => configTemplates[k] == "Fqw").ToArray();
            _practiceTemplateFiles = configTemplates.AllKeys.Where(k => configTemplates[k] == "Practice").ToArray();

            configTemplates = ConfigurationManager.GetSection("reportControllerSettings/practices") as NameValueCollection;
            _practiceKinds = configTemplates.AllKeys.Where(k => configTemplates[k] == "Kind").ToArray();
            _practiceTypes = configTemplates.AllKeys.Where(k => configTemplates[k] == "Type").ToArray();
        }
    }
}