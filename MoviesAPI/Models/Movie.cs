using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;
public class Movie {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = $"The {nameof(Title)} field is required")]
    public string? Title { get; set; }
    [Required(ErrorMessage = $"The {nameof(Director)} field is required")]
    public string? Director { get; set; }
    [Required(ErrorMessage = $"The {nameof(Gender)} field is required")]
    public string? Gender { get; set; }
    [Range(1, 300)]
    public int Duration { get; set; }
}