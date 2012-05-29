using Schematismi.Prism.Infrastructure;

namespace Schematismi.Prism.EditorModule.ViewModel
{
    public interface IEditorViewModel : IViewModel
    {
        string Message { get; set; }
    }
}
