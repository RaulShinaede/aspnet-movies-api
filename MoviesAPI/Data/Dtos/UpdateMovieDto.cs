using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos;
public class UpdateMovieDto {
    [Required(ErrorMessage = $"The {nameof(Title)} field is required")]
    public string? Title { get; set; }
    [Required(ErrorMessage = $"The {nameof(Director)} field is required")]
    public string? Director { get; set; }
    [Required(ErrorMessage = $"The {nameof(Gender)} field is required")]
    public string? Gender { get; set; }
    [Range(1, 300)]
    public int Duration { get; set; }
}