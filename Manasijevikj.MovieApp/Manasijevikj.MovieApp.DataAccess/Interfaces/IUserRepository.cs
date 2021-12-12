using Manasijevikj.MovieApp.Domain.Models;


namespace Manasijevikj.MovieApp.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        User LoginUser(string username, string password);
    }
}
