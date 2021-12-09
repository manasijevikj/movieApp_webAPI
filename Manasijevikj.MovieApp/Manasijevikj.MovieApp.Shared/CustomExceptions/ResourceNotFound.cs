using System;
using System.Collections.Generic;
using System.Text;

namespace Manasijevikj.MovieApp.Shared.CustomExceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(int id, string message) : base(message)
        {

        }
    }
}
