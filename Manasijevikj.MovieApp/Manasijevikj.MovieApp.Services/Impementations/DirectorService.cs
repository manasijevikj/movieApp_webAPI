using Manasijevikj.MovieApp.DataAccess.Interfaces;
using Manasijevikj.MovieApp.Domain.Models;
using Manasijevikj.MovieApp.DTOs.DirectorDTOs;
using Manasijevikj.MovieApp.DTOs.MovieDTOs;
using Manasijevikj.MovieApp.Mappers;
using Manasijevikj.MovieApp.Services.Interfaces;
using Manasijevikj.MovieApp.Shared.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manasijevikj.MovieApp.Services.Impementations
{
    public class DirectorService : IDirectorService
    {
        private IRepository<Director> _directorRepository;
        public DirectorService(IRepository<Director> directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public void AddNewDirector(DirectorDTO entity)
        {
            Director newDirector = entity.ToDirector();
            _directorRepository.Insert(newDirector);
        }

        public void DeleteDirector(int id)
        {
            Director director = _directorRepository.GetById(id);
            if (director == null)
            {
                throw new ResourceNotFoundException("Director not found");
            }
            _directorRepository.Delete(director.Id);
        }

        public List<MovieDTO> FilterMoviesByCountry(string country)
        {
            return _directorRepository.GetAll().Where(x => x.Country.Equals(country, StringComparison.InvariantCultureIgnoreCase)).SelectMany(x => x.Movies.Select(n => n.ToMovieDTO())).ToList();
        }

        public List<DirectorDTO> GetAll()
        {
            return _directorRepository.GetAll().Select(x => x.ToDirectorDTO()).ToList();
        }

        public DirectorDTO GetById(int id)
        {
            Director director = _directorRepository.GetById(id);
            if (director == null)
            {
                throw new ResourceNotFoundException("Director not found");
            }
            return director.ToDirectorDTO();
        }

        public void UpdateDirector(DirectorDTO directorDTO)
        {
            Director director = directorDTO.ToDirector();
            _directorRepository.Update(director);
        }

    }
}
