using System.Windows.Controls;
using Schematismi.Prism.Infrastructure;

namespace Schematismi.Prism.EditorModule
{
    /// <summary>
    /// Interaction logic for EditorView.xaml
    /// </summary>
    public partial class EditorView : UserControl, IView
    {
        public EditorView(IEditorViewViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
