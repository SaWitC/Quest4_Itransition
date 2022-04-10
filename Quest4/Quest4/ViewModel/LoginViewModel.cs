using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quest4.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        //[DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }

    }
}
