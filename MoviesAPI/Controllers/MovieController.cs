using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesAPIController : ControllerBase {
    private static List<Movie> s_movies = new List<Movie>();
    [HttpPost]
    public void AddMovie([FromBody]Movie movie) {
        s_movies.Add(movie);
    }
    [HttpGet]
    public IEnumerable<Movie> GetMovies() {
        return s_movies;
    }
}