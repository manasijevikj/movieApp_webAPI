using Manasijevikj.MovieApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manasijevikj.MovieApp.DTOs.MovieDTOs
{
    public class AddUpdateMovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public MovieGenre Genre { get; set; }
        public int DirectorId { get; set; }

    }
} 
