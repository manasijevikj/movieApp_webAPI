using Manasijevikj.MovieApp.Domain.Enums;
using Manasijevikj.MovieApp.DTOs.MovieDTOs;
using Manasijevikj.MovieApp.Services.Interfaces;
using Manasijevikj.MovieApp.Shared.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manasijevikj.MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }



        [HttpGet]
        public ActionResult<List<MovieDTO>> GetAll()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _movieService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }


        [HttpGet("{id}")]
        public ActionResult<MovieDTO> GetMovie(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _movieService.GetById(id));
            }
            catch (ResourceNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpPost("addMovie")]
        public ActionResult<MovieDTO> AddNewMovie([FromBody] MovieDTO movieDTO)
        {
            try
            {
                _movieService.AddNewMovie(movieDTO);
                return StatusCode(StatusCodes.Status201Created, "Movie created");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }


        [HttpDelete("deleteMovie")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                _movieService.DeleteMovie(id);
                return StatusCode(StatusCodes.Status202Accepted, "Movie deleted");
            }
            catch (ResourceNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Movie not found");
            }
        }


        [HttpPut("updateMovie")]
        public IActionResult UpdateMovie([FromBody] MovieDTO movieDTO)
        {
            try
            {
                _movieService.UpdateMovie(movieDTO);
                return StatusCode(StatusCodes.Status202Accepted);

            }
            catch (ResourceNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpGet("filterByGenreYear")]
        public ActionResult<List<MovieDTO>> Filter(MovieGenre genre, int year)
        {
            try
            {
                if (genre == 0 && year == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Filter parameter required!");
                }
                if (genre == 0)
                {
                    List<MovieDTO> movies = _movieService.GetAll()
                        .Where(x => x.Year == year).ToList();
                    return StatusCode(StatusCodes.Status200OK, movies);
                }
                if (year == 0)
                {
                    List<MovieDTO> movies = _movieService.GetAll()
                        .Where(x => x.Genre == genre).ToList();
                    return StatusCode(StatusCodes.Status200OK, movies);
                }
                List<MovieDTO> moviesFiltered = _movieService.GetAll()
                    .Where(x => x.Genre == genre && x.Year == year).ToList();
                return StatusCode(StatusCodes.Status200OK, moviesFiltered);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Movie not found");
            }
        }




    }
}
