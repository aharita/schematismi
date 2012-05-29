using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Schematismi.Prism.Infrastructure;
using Schematismi.Prism.ToolbarModule.View;
using Schematismi.Prism.ToolbarModule.ViewModel;

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

        /// <summary>
        /// Using View Discovery
        /// </summary>
        public void Initialize()
        {
            _container.RegisterType<ToolbarView>();
            _container.RegisterType<IToolbarViewViewModel, ToolbarViewViewModel>();

            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));
        }
    }
}
