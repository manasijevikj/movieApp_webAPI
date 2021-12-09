using Manasijevikj.MovieApp.Domain.Enums;

namespace Manasijevikj.MovieApp.DTOs.MovieDTOs
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public MovieGenre Genre { get; set; }
        public int DirectorId { get; set; }
    }
}
