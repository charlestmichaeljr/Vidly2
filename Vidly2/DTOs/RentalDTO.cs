using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.DTOs
{
    public class RentalDTO
    {
        public int Id { get; set; }
        [Required]
        public byte? CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}