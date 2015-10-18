using System.Reflection;

namespace Seleniumtest.Provider.Shared.Helpers
{
    public interface IEmbeddedResourceHelper
    {
        string LoadTemplate(Assembly currentAssembly, string resourceName);
    }
}