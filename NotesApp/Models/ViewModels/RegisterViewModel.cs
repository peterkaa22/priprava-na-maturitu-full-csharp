using System.ComponentModel.DataAnnotations;

namespace NotesApp.Models.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Uživatelské jméno je povinné.")]
    [Display(Name = "Uživatelské jméno")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Heslo je povinné.")]
    [DataType(DataType.Password)]
    [Display(Name = "Heslo")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Potvrzení hesla je povinné.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Hesla se neshodují.")]
    [Display(Name = "Potvrzení hesla")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
