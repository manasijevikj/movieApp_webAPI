using Manasijevikj.MovieApp.DataAccess.Interfaces;
using Manasijevikj.MovieApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manasijevikj.MovieApp.DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private MovieAppDbContext _movieAppDbContext;

        public UserRepository(MovieAppDbContext movieAppDbContext)
        {
            _movieAppDbContext = movieAppDbContext;
        }


        public void Delete(int id)
        {
            _movieAppDbContext.Users
                 .Remove(_movieAppDbContext.Users.FirstOrDefault(x => x.Id == id));
            _movieAppDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _movieAppDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _movieAppDbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _movieAppDbContext.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }

        public void Insert(User entity)
        {
            _movieAppDbContext.Users.Add(entity);
            _movieAppDbContext.SaveChanges();
        }

        public User LoginUser(string username, string password)
        {
            return _movieAppDbContext.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower()
                && x.Password == password);
        }

        public void Update(User entity)
        {
            _movieAppDbContext.Users.Update(entity);
            _movieAppDbContext.SaveChanges();
        }
    }
}
