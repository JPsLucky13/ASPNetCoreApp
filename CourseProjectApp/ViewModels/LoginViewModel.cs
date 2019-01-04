using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProjectApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(150,ErrorMessage = "Must be between 5 and 150 characters",MinimumLength = 5)]
        public string Password{ get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
