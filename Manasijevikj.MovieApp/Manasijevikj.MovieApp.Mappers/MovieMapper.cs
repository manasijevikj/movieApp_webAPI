using Manasijevikj.MovieApp.Domain.Models;
using Manasijevikj.MovieApp.DTOs.MovieDTOs;


namespace Manasijevikj.MovieApp.Mappers
{
    public static class MovieMapper
    {
        public static MovieDTO ToMovieDTO(this Movie movie)
        {
            return new MovieDTO
            {
                Description = movie.Description,
                Genre = movie.Genre,
                DirectorId = movie.DirectorId,
                Title = movie.Title,
                Year = movie.Year
            };
        }

        public static Movie ToMovie(this MovieDTO movie)
        {
            return new Movie
            {
                Description = movie.Description,
                Genre = movie.Genre,
                DirectorId = movie.DirectorId,
                Title = movie.Title,
                Year = movie.Year
            };
        }


        public static AddUpdateMovieDTO ToAddUpdateMovieDTO(this Movie movie)
        {
            return new AddUpdateMovieDTO
            {
                Id = movie.Id,
                Description = movie.Description,
                Genre = movie.Genre,
                DirectorId = movie.DirectorId,
                Title = movie.Title,
                Year = movie.Year
            };
        }

        public static Movie ToMovie(this AddUpdateMovieDTO movie)
        {
            return new Movie
            {
                Id = movie.Id,
                Description = movie.Description,
                Genre = movie.Genre,
                DirectorId = movie.DirectorId,
                Title = movie.Title,
                Year = movie.Year
            };
        }
    }
}
