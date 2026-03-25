using System.ComponentModel.DataAnnotations;

namespace NotesApp.Models;

public class Note
{
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(4000)]
    public string Content { get; set; } = string.Empty;

    public bool IsImportant { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    public ApplicationUser? User { get; set; }
}
