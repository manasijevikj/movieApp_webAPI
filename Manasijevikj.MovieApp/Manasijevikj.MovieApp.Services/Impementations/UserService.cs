using Manasijevikj.MovieApp.DataAccess.Interfaces;
using Manasijevikj.MovieApp.Domain.Models;
using Manasijevikj.MovieApp.DTOs.UserDTO;
using Manasijevikj.MovieApp.Services.Interfaces;
using Manasijevikj.MovieApp.Shared;
using Manasijevikj.MovieApp.Shared.CustomExceptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Manasijevikj.MovieApp.Services.Impementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        IOptions<AppSettings> _options;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _options = options;
        }

        public string Login(LoginUserDTO loginUserDTO)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] hashedBytes = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(loginUserDTO.Password));
            string hashedPassword = Encoding.ASCII.GetString(hashedBytes);

            User userDb = _userRepository.LoginUser(loginUserDTO.Username, hashedPassword);
            if (userDb == null)
            {
                throw new ResourceNotFoundException($"Could not login user {loginUserDTO.Username}");
            }

            //GENERATE JWT TOKEN

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes(_options.Value.SecretKey);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(2), // The token will be valid for one hour
                //Signature configuration
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                     SecurityAlgorithms.HmacSha256Signature),
                //Payload
                Subject = new ClaimsIdentity(
                    new[]
                   {
                        new Claim(ClaimTypes.Name, userDb.Username),
                        new Claim(ClaimTypes.NameIdentifier, userDb.Id.ToString()),
                        new Claim("userFullName", $"{userDb.FirstName} {userDb.LastName}"),
                        new Claim(ClaimTypes.Role, userDb.Role)
                    }
                )
            };
            //Generate token with the configuration
            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            //Convert it to string
            return jwtSecurityTokenHandler.WriteToken(token);

        }

        public void Register(RegisterUserDTO registerUserDTO)
        {
            ValidateUser(registerUserDTO);

            //use MD5 hash algorithm
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            //get the bytes from the password string
            byte[] passwordBytes = Encoding.ASCII.GetBytes(registerUserDTO.Password);
            //get the hash
            byte[] passwordHash = mD5CryptoServiceProvider.ComputeHash(passwordBytes);
            //get the string hash
            string hashedPasword = Encoding.ASCII.GetString(passwordHash);


            User newUser = new User
            {
                FirstName = registerUserDTO.FirstName,
                LastName = registerUserDTO.LastName,
                Username = registerUserDTO.Username,
                Role = registerUserDTO.Role,
                Password = hashedPasword //We send the hashed password value to the db
            };
            _userRepository.Insert(newUser);
        }

        private void ValidateUser(RegisterUserDTO registerUserDto)
        {
            if (string.IsNullOrEmpty(registerUserDto.Username) || string.IsNullOrEmpty(registerUserDto.Password))
            {
                throw new UserException("Username and password are required fields!");
            }
            if (string.IsNullOrEmpty(registerUserDto.Role))
            {
                throw new UserException("Role is a required field!");
            }
            if (registerUserDto.Username.Length > 30)
            {
                throw new UserException("Username can contain maximum 30 characters!");
            }
            if (registerUserDto.FirstName.Length > 50 || registerUserDto.LastName.Length > 50)
            {
                throw new UserException("Firstname and Lastname can contain maximum 50 characters!");
            }
            if (!IsUserNameUnique(registerUserDto.Username))
            {
                throw new UserException("A user with this username already exists!");
            }
            if (registerUserDto.Password != registerUserDto.ConfirmedPassword)
            {
                throw new UserException("The passwords do not match!");
            }
            if (!IsPasswordValid(registerUserDto.Password))
            {
                throw new UserException("The password is not complex enough!");
            }
        }

        private bool IsUserNameUnique(string username)
        {
            return _userRepository.GetUserByUsername(username) == null;
        }

        private bool IsPasswordValid(string password)
        {
            Regex passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            return passwordRegex.Match(password).Success;
        }
    }
}
