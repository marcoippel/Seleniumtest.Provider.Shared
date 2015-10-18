using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seleniumtest.Provider.Shared.Helpers
{
    public class UrlHelper : IUrlHelper
    {
        public string GetEnvironmentName(string url)
        {
            Uri uri = new Uri(url);

            string host = uri.Host;
            return !string.IsNullOrEmpty(ConfigurationManager.AppSettings[host]) ? string.Format("/{0}", ConfigurationManager.AppSettings[host]) : string.Empty;
        }
    }
}
