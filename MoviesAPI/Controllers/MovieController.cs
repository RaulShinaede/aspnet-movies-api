using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Data;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesAPIController : ControllerBase {

    private MovieDbContext _context;
    public MoviesAPIController(MovieDbContext context) {
        this._context = context;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody]Movie movie) {

        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new { movie.Id }, movie);
    }
    [HttpGet]
    public IActionResult GetMovies() {
        return Ok(_context.Movies);
    }
    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id) {
        var movie = _context.Movies
            .FirstOrDefault(x => x.Id == id);

        if (movie == null) return NotFound(movie);

        return Ok(movie);
    }
}