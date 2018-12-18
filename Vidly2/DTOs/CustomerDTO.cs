﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        
        public byte? MembershipTypeId { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }
    }
}