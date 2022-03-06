using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;
public class Movie {
    [Required]
    public string Title { get; set; }
    [Required]
    public string Director { get; set; }
    public string Gender { get; set; }
    [Range(1, 300)]
    public int Duraction { get; set; }
}