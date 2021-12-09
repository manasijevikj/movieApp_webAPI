using System.Collections.Generic;


namespace Manasijevikj.MovieApp.Domain.Models
{
    public class Director : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public List<Movie> Movies { get; set; }
        public Director()
        {
            Movies = new List<Movie>();
        }
    }
}