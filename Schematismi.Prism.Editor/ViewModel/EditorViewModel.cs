using System;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using Schematismi.Interfaces;
using Schematismi.Prism.Editor.View;
using Schematismi.Prism.Infrastructure;

namespace Schematismi.Prism.Editor.ViewModel
{
    public class EditorViewModel : ViewModelBase, IEditorViewModel, INotifyPropertyChanged
    {
        readonly IUnityContainer _container;

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public EditorViewModel(IUnityContainer container, IEditorView view)
            : base(view)
        {
            _container = container;
            GlobalCommands.superTestMethod.RegisterCommand(
                new DelegateCommand(OpenFileAndReplace, CanOpenFileAndReplace));
        }

        private bool CanOpenFileAndReplace()
        {
            return true;
        }

        private void OpenFileAndReplace()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "XML Configuration File|*.xml";
            var result = dialog.ShowDialog();
            if (result.Value)
            {
                _container.Resolve<IConfigurationReplaceRules>().Execute(dialog.FileName);
                Message = string.Format("Executed succesfully at {0}", DateTime.Now.ToString());

                // TODO: add controls dynamically here
                // TODO: need to create a new control with all the lists and controls i may need
                // example, a control that holds a list of applications, with all the configuration
                var viewContentStackPanel = (System.Windows.Controls.StackPanel)(((EditorView)View).Content);
                viewContentStackPanel.Children.Add(new System.Windows.Controls.Button() { Content = "Hello" });
            }
        }
    }
}
