using System;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using Schematismi.Interfaces;
using Schematismi.Prism.Infrastructure;

namespace Schematismi.Prism.Editor.ViewModel
{
    public class EditorViewModel : ViewModelBase, IEditorViewModel, INotifyPropertyChanged
    {
        readonly IUnityContainer _container;
        public DelegateCommand TestCommand { get; set; }

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

        public EditorViewModel(IUnityContainer container)
        {
            _container = container;
            TestCommand = new DelegateCommand(TestMethod, CanTestMethod);
            GlobalCommands.superTestMethod.RegisterCommand(TestCommand);
        }

        private bool CanTestMethod()
        {
            return true;
        }

        private void TestMethod()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "XML Configuration File|*.xml";
            var result = dialog.ShowDialog();
            if (result.Value)
            {
                _container.Resolve<IConfigurationReplaceRules>().Execute(dialog.FileName);
                Message = string.Format("Executed succesfully at {0}", DateTime.Now.ToString());
            }
        }
    }
}
