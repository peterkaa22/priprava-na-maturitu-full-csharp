using System.ComponentModel.DataAnnotations;

namespace NotesApp.Models.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Uživatelské jméno je povinné.")]
    [Display(Name = "Uživatelské jméno")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Heslo je povinné.")]
    [DataType(DataType.Password)]
    [Display(Name = "Heslo")]
    public string Password { get; set; } = string.Empty;
}
