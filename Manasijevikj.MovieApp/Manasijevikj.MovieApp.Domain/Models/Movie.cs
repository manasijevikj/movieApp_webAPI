using Manasijevikj.MovieApp.Domain.Enums;

namespace Manasijevikj.MovieApp.Domain.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public MovieGenre Genre { get; set; }
        public Director Director { get; set; }
        public int DirectorId { get; set; }

    }
}
