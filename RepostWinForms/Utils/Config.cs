using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace RepostWinForms.Utils
{
    public sealed class Config
    {
        private static readonly Lazy<Config> LazyInstance = new Lazy<Config>(() => new Config());
        
        public static Config Instance => LazyInstance.Value;
        
        public int MaxStatusLenght { get; }
        
        public string DefaultFolder { get; }

        private Config()
        {
            var config = ConfigurationManager.GetSection("reportWinFormsSettings") as NameValueCollection;
            MaxStatusLenght = int.Parse(config["MaxStatusLenght"] as string);
            DefaultFolder = config["DefaultFolder"] as string;
        }
    }
}