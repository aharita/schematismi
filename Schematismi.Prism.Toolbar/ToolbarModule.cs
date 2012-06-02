using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Schematismi.Prism.Infrastructure;
using Schematismi.Prism.Toolbar.View;
using Schematismi.Prism.Toolbar.ViewModel;

namespace Schematismi.Prism.Toolbar
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

        /// <summary>
        /// Using View Discovery
        /// </summary>
        public void Initialize()
        {
            _container.RegisterType<ToolbarView>();
            _container.RegisterType<IToolbarViewModel, ToolbarViewModel>();

            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));
        }
    }
}
