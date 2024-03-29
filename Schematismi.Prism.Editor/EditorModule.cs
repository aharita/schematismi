﻿using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Schematismi.Prism.Editor.View;
using Schematismi.Prism.Editor.ViewModel;
using Schematismi.Prism.Infrastructure;

namespace Schematismi.Prism.Editor
{
    public class EditorModule : IModule
    {
        readonly IUnityContainer _container;
        readonly IRegionManager _regionManager;

        public EditorModule(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        // Using View Composition
        public void Initialize()
        {
            _container.RegisterType<IEditorView, EditorView>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IEditorViewModel, EditorViewModel>(new ContainerControlledLifetimeManager());

            var viewModel = _container.Resolve<IEditorViewModel>();
            var view = _container.Resolve<EditorView>();

            viewModel.Message = "Hi";
            view.ViewModel = viewModel;

            IRegion region = _regionManager.Regions[RegionNames.EditorRegion];
            region.Add(view);
        }
    }
}
