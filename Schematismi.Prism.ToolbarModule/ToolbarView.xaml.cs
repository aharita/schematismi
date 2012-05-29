using System.Windows.Controls;
using Schematismi.Prism.Infrastructure;

namespace Schematismi.Prism.ToolbarModule
{
    /// <summary>
    /// Interaction logic for ToolbarView.xaml
    /// </summary>
    public partial class ToolbarView : UserControl, IView
    {
        public ToolbarView(IToolbarViewViewModel viewModel)
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
