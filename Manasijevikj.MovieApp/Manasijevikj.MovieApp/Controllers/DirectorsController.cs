using Manasijevikj.MovieApp.DTOs.DirectorDTOs;
using Manasijevikj.MovieApp.Services.Interfaces;
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
    }
}
