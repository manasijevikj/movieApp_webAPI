using Manasijevikj.MovieApp.DTOs.MovieDTOs;
using System.Collections.Generic;


namespace Manasijevikj.MovieApp.DTOs.DirectorDTOs
{
    public class DirectorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public List<MovieDTO> Movies { get; set; }

        public DirectorDTO()
        {
            Movies = new List<MovieDTO>();
        }
    }
}
