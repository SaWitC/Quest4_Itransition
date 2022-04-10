using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quest4.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(3,ErrorMessage ="name is so short"),MaxLength(30,ErrorMessage ="Name is so long")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string Pass { get; set; }
        [Required]
        [Display(Name ="Confirm Password")]
        [Compare("Pass")]
        public string ConfirmPass { get; set; }
    }
}
