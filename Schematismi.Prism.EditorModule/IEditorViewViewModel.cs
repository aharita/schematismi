using Schematismi.Prism.Infrastructure;

namespace Schematismi.Prism.EditorModule
{
    public interface IEditorViewViewModel : IViewModel
    {
        string Message { get; set; }
    }
}
