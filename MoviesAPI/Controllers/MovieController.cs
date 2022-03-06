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
        return CreatedAtAction(nameof(Get_ID), new { movie.Id }, movie);
    }
    [HttpGet]
    public IActionResult Get() {
        return Ok(_context.Movies);
    }
    [HttpGet("{id}")]
    public IActionResult Get_ID(int id) {
        var movie = GetMovieById(id);
        return movie == null ? Ok(movie) : NotFound();
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Movie newMovie) {
        var movie = GetMovieById(id);
        if (movie == null) return NotFound(movie);

        movie.Director = newMovie.Director;
        movie.Title = newMovie.Title;
        movie.Duration = newMovie.Duration;
        movie.Gender = newMovie.Gender;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        var movie = GetMovieById(id);
        if (movie == null) return NotFound(movie);

        _context.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }

    #region  private
    private Movie GetMovieById(int id) {
        return _context.Movies.FirstOrDefault(movie => movie.Id == id);
    }

    #endregion
}