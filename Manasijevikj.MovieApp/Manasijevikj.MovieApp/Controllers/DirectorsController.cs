using Manasijevikj.MovieApp.DTOs.DirectorDTOs;
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
    public class DirectorsController : ControllerBase
    {
        private IMovieService _movieService;
        private IDirectorService _directorService;

        public DirectorsController(IMovieService movieService, IDirectorService directorService)
        {
            _movieService = movieService;
            _directorService = directorService;
        }

        [HttpGet]
        public ActionResult<List<DirectorDTO>> GetAllDirectors()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _directorService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpGet("getDirectorById")]
        public ActionResult<DirectorDTO> GetDirector(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _directorService.GetById(id));
            }
            catch (ResourceNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }



        [HttpPost("addDirector")]
        public ActionResult<DirectorDTO> AddNewDirector([FromBody] DirectorDTO directorDTO)
        {
            try
            {
                _directorService.AddNewDirector(directorDTO);
                return StatusCode(StatusCodes.Status201Created, "Director created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }


        [HttpDelete("deleteDrector")]
        public IActionResult DeleteDirector(int id)
        {
            try
            {
                    _directorService.DeleteDirector(id);
                    return StatusCode(StatusCodes.Status202Accepted);                      
            }
            catch (ResourceNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }



        [HttpPut("updateDirector")]
        public IActionResult UpdateDirector([FromBody] DirectorDTO directorDTO)
        {
            try
            {
                if (directorDTO != null)
                {
                    _directorService.UpdateDirector(directorDTO);
                    return StatusCode(StatusCodes.Status202Accepted);
                }
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Director not found");
            }
        }


        [HttpGet("filterByCountry")]
        public ActionResult<List<MovieDTO>> Filter(string country)
        {
            try
            {
                if (string.IsNullOrEmpty(country))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Filter parameter required!");
                }
                return StatusCode(StatusCodes.Status200OK, _directorService.FilterMoviesByCountry(country));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Movie not found");
            }
        }

    }
}
