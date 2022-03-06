using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using AutoMapper;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesAPIController : ControllerBase {

    private MovieDbContext _context;
    private IMapper _mapper;
    public MoviesAPIController(
        MovieDbContext context,
        IMapper mapper) {

        this._context = context;
        this._mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody]CreateMovieDto createMovieDto) {

        Movie movie = _mapper.Map<Movie>(createMovieDto);

        _context.Movies?.Add(movie);
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
        if (movie == null) return NotFound();

        return Ok(_mapper.Map<ReadMovieDto>(movie));
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateMovieDto updateMovieDto) {
        var movie = GetMovieById(id);
        if (movie == null) return NotFound(movie);

        _mapper.Map(updateMovieDto, movie);
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
    private Movie? GetMovieById(int id) {
        return _context.Movies?.FirstOrDefault(movie => movie.Id == id);
    }

    #endregion
}