using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Schematismi.Prism.Infrastructure;

namespace Schematismi.Prism.ToolbarModule
{
    public class ToolbarModule : IModule
    {
        readonly IUnityContainer _container;
        readonly IRegionManager _regionManager;

        public ToolbarModule(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));
        }
    }
}
