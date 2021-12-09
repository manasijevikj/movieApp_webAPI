using Manasijevikj.MovieApp.DTOs.DirectorDTOs;
using Manasijevikj.MovieApp.DTOs.MovieDTOs;
using System.Collections.Generic;


namespace Manasijevikj.MovieApp.Services.Interfaces
{
    public interface IDirectorService
    {
        List<DirectorDTO> GetAll();
        DirectorDTO GetById(int id);
        void AddNewDirector(DirectorDTO entity);
        void DeleteDirector(int id);
        void UpdateDirector(DirectorDTO directorDTO);
        List<MovieDTO> FilterMoviesByCountry(string country);
    }
}
