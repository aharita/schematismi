using System.Windows.Controls;
using Schematismi.Prism.Infrastructure;
using Schematismi.Prism.ToolbarModule.ViewModel;

namespace Schematismi.Prism.ToolbarModule.View
{
    /// <summary>
    /// Interaction logic for ToolbarView.xaml
    /// </summary>
    public partial class ToolbarView : UserControl, IView
    {
        public ToolbarView(IToolbarViewModel viewModel)
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
