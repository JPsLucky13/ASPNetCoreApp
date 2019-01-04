using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProjectApp.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(60,ErrorMessage = "The Password must be between 6 and 60 characters long!!!",MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Comfirm Password")]
        [Compare("Password",ErrorMessage = "The Password and the Confirmation must match each other!!!")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
