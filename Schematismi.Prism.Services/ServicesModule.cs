using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Schematismi.Common;
using Schematismi.Interfaces;

namespace Schematismi.Prism.Services
{
    public class ServicesModule : IModule
    {
        readonly IUnityContainer _container;

        public ServicesModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IConfigurationReplaceRules, ConfigurationReplaceRules>(new ContainerControlledLifetimeManager());
        }
    }
}
