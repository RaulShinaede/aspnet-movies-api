using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesAPIController : ControllerBase {
    private static List<Movie> s_movies = new List<Movie>();
    private static int Id = 1;
    [HttpPost]
    public IActionResult AddMovie([FromBody]Movie movie) {
        movie.Id = Id++;
        s_movies.Add(movie);

        return CreatedAtAction(nameof(GetMovieById), new { movie.Id }, movie);
    }
    [HttpGet]
    public IActionResult GetMovies() {
        return Ok(s_movies);
    }
    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id) {
        var movie = s_movies.First(
            x => x.Id == id);

        if (movie == null) return NotFound(movie);

        return Ok(movie);
    }
}