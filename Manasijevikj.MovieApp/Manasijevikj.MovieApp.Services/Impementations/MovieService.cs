using Manasijevikj.MovieApp.DataAccess.Interfaces;
using Manasijevikj.MovieApp.Domain.Models;
using Manasijevikj.MovieApp.DTOs.MovieDTOs;
using Manasijevikj.MovieApp.Mappers;
using Manasijevikj.MovieApp.Services.Interfaces;
using Manasijevikj.MovieApp.Shared.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manasijevikj.MovieApp.Services.Impementations
{
    public class MovieService : IMovieService
    {
        private IRepository<Movie> _movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }



        public void AddNewMovie(MovieDTO entity)
        {
            Movie newMovie = entity.ToMovie();
            _movieRepository.Insert(newMovie);
        }

        public void DeleteMovie(int id)
        {
            Movie movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            _movieRepository.Delete(movie.Id);
        }

        public List<MovieDTO> GetAll()
        {
            return _movieRepository.GetAll().Select(x => x.ToMovieDTO()).ToList();
        }

        public MovieDTO GetById(int id)
        {
            Movie movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new ResourceNotFoundException("Movie not found");
            }
            return movie.ToMovieDTO();
        }

        public void UpdateMovie(MovieDTO movieDTO)
        {
            Movie movie = movieDTO.ToMovie();
            _movieRepository.Update(movie);
        }
    }
}
