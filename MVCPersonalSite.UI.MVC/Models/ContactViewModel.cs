using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // Used for our Metadata

namespace MVCPersonlSite.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "* Required")]
        [UIHint("Multiline Text")]
        public string Message { get; set; }
    }
}