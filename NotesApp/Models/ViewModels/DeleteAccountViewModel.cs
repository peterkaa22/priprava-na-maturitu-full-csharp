using System.ComponentModel.DataAnnotations;

namespace NotesApp.Models.ViewModels;

public class DeleteAccountViewModel
{
    [Required(ErrorMessage = "Pro zrušení účtu zadej heslo.")]
    [DataType(DataType.Password)]
    [Display(Name = "Heslo")]
    public string Password { get; set; } = string.Empty;
}
