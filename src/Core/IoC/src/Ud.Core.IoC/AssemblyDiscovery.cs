using System.Reflection;
using System.Runtime.Loader;
using Ud.Core.Abstractions.Library;
using Ud.Core.IoC.Abstractions;

namespace Ud.Core.IoC
{
    public class AssemblyDiscovery : SingletonBase<AssemblyDiscovery>, IAssemblyDiscovery
    {
        public Assembly ApiAssembly { get; }
        public IEnumerable<Assembly> AbstractionAssemblies { get; }
        public IEnumerable<Assembly> ApplicationAssemblies { get; }
        public IEnumerable<Assembly> CoreAssemblies { get; }
        public IEnumerable<Assembly> DomainAssemblies { get; }
        public IEnumerable<Assembly> RepositoryAssemblies { get; }
        public IEnumerable<Assembly> CommonAssemblies { get; }
        public AssemblyDiscovery()
        {
            ApiAssembly = Assembly.GetEntryAssembly();

            var path = Path.GetDirectoryName(ApiAssembly.Location);
            var moduleAssemblies = Directory
                                    .GetFiles(path, "*.dll", SearchOption.TopDirectoryOnly)
                                    .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                                    .ToList();

            AbstractionAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Abstractions"));
            ApplicationAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Application"));
            CoreAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Core"));
            DomainAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Domain"));
            RepositoryAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Persistence"));
            CommonAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Common"));
        }
    }
}
