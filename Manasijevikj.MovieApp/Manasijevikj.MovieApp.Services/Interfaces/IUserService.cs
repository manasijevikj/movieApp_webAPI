using Manasijevikj.MovieApp.DTOs.UserDTO;


namespace Manasijevikj.MovieApp.Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterUserDTO registerUserDTO);
        string Login(LoginUserDTO loginUserDTO);
    }
}
