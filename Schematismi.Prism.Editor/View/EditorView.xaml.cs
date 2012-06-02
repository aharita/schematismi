using System.Windows.Controls;

using Schematismi.Prism.Infrastructure;

namespace Schematismi.Prism.Editor.View
{
    /// <summary>
    /// Interaction logic for EditorView.xaml
    /// </summary>
    public partial class EditorView : UserControl, IEditorView
    {
        public EditorView()
        {
            InitializeComponent();
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
