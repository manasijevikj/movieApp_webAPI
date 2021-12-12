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



        public void AddNewMovie(AddUpdateMovieDTO entity)
        {
            Movie newMovie = new Movie(); // Autoincrement ID
            int id = newMovie.Id;
            newMovie = entity.ToMovie();
            newMovie.Id = id;
            _movieRepository.Insert(newMovie);
        }

        public void DeleteMovie(int id)
        {
            
            Movie movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new ResourceNotFoundException("Movie not found");
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
         
        public void UpdateMovie(AddUpdateMovieDTO updateMovieDTO)
        {
            Movie movie = _movieRepository.GetById(updateMovieDTO.Id);
            if (movie == null)
            {
                throw new ResourceNotFoundException($"Movie with id {updateMovieDTO.Id} was not found");
            }

            //Don't forget Validation 

            movie.Title = updateMovieDTO.Title;
            movie.Description = updateMovieDTO.Description;
            movie.Year = updateMovieDTO.Year;
            movie.Genre = updateMovieDTO.Genre;
            movie.DirectorId = updateMovieDTO.DirectorId;

            _movieRepository.Update(movie);
        }
    }
}
