using System;
using System.Collections.Specialized;
using System.Configuration;

namespace TemplateDocEditor.Utils
{
    public sealed class Config
    {
        private static readonly Lazy<Config> LazyInstance = new Lazy<Config>(() => new Config());
        
        public static Config Instance => LazyInstance.Value;
        
        public string ColumnTagExpression { get; }
        public int FrontOffsetTag { get; }
        public int BackOffsetTag { get; }

        private Config()
        {
            var config = ConfigurationManager.GetSection("templateDocEditorSettings") as NameValueCollection;
            FrontOffsetTag = int.Parse(config["FrontOffsetTag"] as string);
            BackOffsetTag = int.Parse(config["BackOffsetTag"] as string);
            ColumnTagExpression = config["ColumnTagExpression"] as string;
        }
    }
}