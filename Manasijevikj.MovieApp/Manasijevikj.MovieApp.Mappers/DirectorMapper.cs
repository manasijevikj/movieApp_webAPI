using Manasijevikj.MovieApp.Domain.Models;
using Manasijevikj.MovieApp.DTOs.DirectorDTOs;
using System.Linq;


namespace Manasijevikj.MovieApp.Mappers
{
    public static class DirectorMapper
    {
        public static DirectorDTO ToDirectorDTO(this Director director)
        {
            return new DirectorDTO()
            {
                Country = director.Country,
                FirstName = director.FirstName,
                LastName = director.LastName,
                Movies = director.Movies.Select(x => x.ToMovieDTO()).ToList()
            };
        }

        public static Director ToDirector(this DirectorDTO director)
        {
            return new Director()
            {
                Country = director.Country,
                FirstName = director.FirstName,
                LastName = director.LastName,
                Movies = director.Movies.Select(x => x.ToMovie()).ToList()
            };
        }
    }
}
