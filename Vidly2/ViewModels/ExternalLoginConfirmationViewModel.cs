using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Driver's License")]
        public string DriversLicense { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [MaxLength(50)]
        public string Phone { get; set; }
    }
}