using Manasijevikj.MovieApp.DataAccess;
using Manasijevikj.MovieApp.DataAccess.Implementations;
using Manasijevikj.MovieApp.DataAccess.Interfaces;
using Manasijevikj.MovieApp.Domain.Models;
using Manasijevikj.MovieApp.Services.Impementations;
using Manasijevikj.MovieApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Manasijevikj.MovieApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieAppDbContext>(x =>
                x.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Movie>, MovieRepository>();
            services.AddTransient<IRepository<Director>, DirectorRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IDirectorService, DirectorService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
