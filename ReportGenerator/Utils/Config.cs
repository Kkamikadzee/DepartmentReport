using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace ReportGenerator.Utils
{
    public sealed class Config
    {
        private static readonly Lazy<Config> LazyInstance = new Lazy<Config>(() => new Config());
        
        public static Config Instance => LazyInstance.Value;

        private readonly NameValueCollection _knownFiles;

        private readonly ICollection<string> _templateExtensions;
        
        private readonly string _directoryWithTemplates;
        
        public ICollection<string> KnownFiles => _knownFiles.AllKeys;
        public IDictionary<string, string> KnownFilesTypes =>
            _knownFiles.AllKeys.ToDictionary(k => k, k => _knownFiles[k]);

        public ICollection<string> TemplateExtensions => _templateExtensions;

        public string DirectoryWithTemplates => _directoryWithTemplates;

        private Config()
        {
            _knownFiles = ConfigurationManager.GetSection("reportGeneratorSettings/reportTypes") as NameValueCollection;

            var otherConfig = ConfigurationManager.GetSection("reportGeneratorSettings/other") as NameValueCollection;
            _templateExtensions = (otherConfig["TemplateExtensions"] as string).Split(';');
            _directoryWithTemplates = otherConfig["DirectoryWithTemplates"] as string;
        }
    }
}