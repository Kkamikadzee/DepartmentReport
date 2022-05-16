using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace DepartmentReportGenerator.Utils
{
    public sealed class Config
    {
        private static readonly Lazy<Config> LazyInstance = new Lazy<Config>(() => new Config());
        
        public static Config Instance => LazyInstance.Value;

        private readonly NameValueCollection _config;
        
        public string this[string configKey] => _config[configKey];
        public ICollection<string> KnownFiles => _config.AllKeys;

        private Config()
        {
            _config = ConfigurationManager.GetSection("ReportGeneratorSettings") as NameValueCollection;
        }
    }
}