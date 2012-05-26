using System;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace Schematismi.Prism
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    ModuleCatalog catalog = new ModuleCatalog();
        //    catalog.AddModule(typeof(MainModule.MainModule));
        //    return catalog;
        //}

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(
                new Uri("/Schematismi.Prism;component/XamlCatalog.xaml", UriKind.Relative));
        }
    }
}
