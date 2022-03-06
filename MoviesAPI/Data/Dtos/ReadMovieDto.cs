using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos;
public class ReadMovieDto {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Director { get; set; }
    public string? Gender { get; set; }
    public int Duration { get; set; }
}