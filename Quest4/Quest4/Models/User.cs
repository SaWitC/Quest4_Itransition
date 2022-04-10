using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Quest4.Models
{
    public class User:IdentityUser
    {
        public bool IsBaned { get; set; } = false;
        public DateTime RegisterDate { get; set; }
        public DateTime LastLog { get; set; }

        [Display(Name = "Status")]
        [ForeignKey("StatusId")]
        public StatusModel Status { get; set; }
        [Display(Name = "Status")]
        public int? StatusId { get; set; }
    }
}
