using System.Reflection;

namespace Ud.Core.IoC.Abstractions
{
    public interface IAssemblyDiscovery
    {
        public Assembly ApiAssembly { get; }
        public IEnumerable<Assembly> AbstractionAssemblies { get; }
        public IEnumerable<Assembly> ApplicationAssemblies { get; }
        public IEnumerable<Assembly> CoreAssemblies { get; }
        public IEnumerable<Assembly> DomainAssemblies { get; }
        public IEnumerable<Assembly> RepositoryAssemblies { get; }
        public IEnumerable<Assembly> CommonAssemblies { get; }
    }
}
