using Manasijevikj.MovieApp.DataAccess.Interfaces;
using Manasijevikj.MovieApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Manasijevikj.MovieApp.DataAccess.Implementations
{
    public class DirectorRepository : IRepository<Director>
    {
        private MovieAppDbContext _movieAppDbContext;

        public DirectorRepository(MovieAppDbContext movieAppDbContext)
        {
            _movieAppDbContext = movieAppDbContext;
        }



        public void Delete(int id)
        {
            _movieAppDbContext.Directors
                 .Remove(_movieAppDbContext.Directors.FirstOrDefault(x => x.Id == id));
            _movieAppDbContext.SaveChanges();
        }

        public List<Director> GetAll()
        {
            return _movieAppDbContext.Directors
                .Include(x => x.Movies)
                .ToList();
        }

        public Director GetById(int id)
        {
            return _movieAppDbContext.Directors
                .Include(x => x.Movies)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Director entity)
        {
            _movieAppDbContext.Directors.Add(entity);
            _movieAppDbContext.SaveChanges();
        }

        public void Update(Director entity)
        {
            _movieAppDbContext.Directors.Update(entity);
            _movieAppDbContext.SaveChanges();
        }
    }
}
