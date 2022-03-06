using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;
public class Movie {
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Director { get; set; }
    public string Gender { get; set; }
    [Range(1, 300)]
    public int Duration { get; set; }
}