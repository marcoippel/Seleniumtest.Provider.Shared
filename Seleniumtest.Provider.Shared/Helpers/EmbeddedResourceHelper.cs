using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Seleniumtest.Provider.Shared.Helpers
{
    public class EmbeddedResourceHelper : IEmbeddedResourceHelper
    {
        public string LoadTemplate(Assembly currentAssembly, string resourceName)
        {
            if (currentAssembly == null)
            {
                throw new ArgumentNullException("currentAssembly");
            }

            var resource = currentAssembly.GetManifestResourceNames().FirstOrDefault(r => r.EndsWith(resourceName));
            if (resource == null)
            {
                throw new NullReferenceException(string.Format("Resource ending with name {0} not found", resourceName));
            }

            Stream htmlTemplateFile = currentAssembly.GetManifestResourceStream(resource);
            if (htmlTemplateFile == null)
            {
                throw new NullReferenceException(
                    string.Format("Profile xml ending with name {0} not loaded from assembly", resourceName));
            }

            StreamReader reader = new StreamReader(htmlTemplateFile);
            string html = reader.ReadToEnd();

            return html;
        }
    }
}