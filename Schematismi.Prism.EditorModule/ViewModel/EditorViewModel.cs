using System;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;
using Schematismi.Prism.Infrastructure;

namespace Schematismi.Prism.EditorModule.ViewModel
{
    public class EditorViewModel : ViewModelBase, IEditorViewModel, INotifyPropertyChanged
    {
        public DelegateCommand TestCommand { get; set; }

        private string _message;
        public string Message
        {
            get { return _message; }

            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public EditorViewModel()
        {
            TestCommand = new DelegateCommand(TestMethod, CanTestMethod);
            GlobalCommands.SuperTestMethod.RegisterCommand(TestCommand);
        }

        private bool CanTestMethod()
        {
            return true;
        }

        private void TestMethod()
        {
            Message = DateTime.Now.ToString();
        }
    }
}
