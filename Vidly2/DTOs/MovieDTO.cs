using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        
        [Required]
        public byte GenreId { get; set; }

        public GenreDTO Genre { get; set; }
        
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }
    }
}