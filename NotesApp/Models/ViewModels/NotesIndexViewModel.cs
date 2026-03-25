namespace NotesApp.Models.ViewModels;

public class NotesIndexViewModel
{
    public CreateNoteViewModel NewNote { get; set; } = new();

    public IReadOnlyList<Note> Notes { get; set; } = [];

    public bool ShowImportantOnly { get; set; }
}
