using System;


namespace Manasijevikj.MovieApp.Shared.CustomExceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {

        }
    }
}
