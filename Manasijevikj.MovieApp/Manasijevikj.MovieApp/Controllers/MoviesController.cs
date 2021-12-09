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


    }
}
