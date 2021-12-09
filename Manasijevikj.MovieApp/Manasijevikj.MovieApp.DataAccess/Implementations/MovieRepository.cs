
using Manasijevikj.MovieApp.DataAccess.Interfaces;
using Manasijevikj.MovieApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Manasijevikj.MovieApp.DataAccess.Implementations
{
    public class MovieRepository : IRepository<Movie>
    {
        private MovieAppDbContext _movieAppDbContext;

        public MovieRepository(MovieAppDbContext movieAppDbContext)
        {
            _movieAppDbContext = movieAppDbContext;
        }



        public void Delete(int id)
        {
            _movieAppDbContext.Movies
                .Remove(_movieAppDbContext.Movies.FirstOrDefault(x => x.Id == id));
            _movieAppDbContext.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return _movieAppDbContext.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _movieAppDbContext.Movies.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Movie entity)
        {
            _movieAppDbContext.Movies.Add(entity);
            _movieAppDbContext.SaveChanges();
        }

        public void Update(Movie entity)
        {
            _movieAppDbContext.Movies.Update(entity);
            _movieAppDbContext.SaveChanges();
        }
    }
}
