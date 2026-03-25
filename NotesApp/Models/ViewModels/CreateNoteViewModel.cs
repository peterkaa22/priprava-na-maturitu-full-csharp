using System.ComponentModel.DataAnnotations;

namespace NotesApp.Models.ViewModels;

public class CreateNoteViewModel
{
    [Required(ErrorMessage = "Nadpis je povinný.")]
    [MaxLength(120, ErrorMessage = "Nadpis může mít maximálně 120 znaků.")]
    [Display(Name = "Nadpis")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Text poznámky je povinný.")]
    [MaxLength(4000, ErrorMessage = "Text může mít maximálně 4000 znaků.")]
    [Display(Name = "Text")]
    public string Content { get; set; } = string.Empty;
}
