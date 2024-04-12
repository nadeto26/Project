using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineSite.Core.Models.Admin
{
    public class UserServiceModel
    {
        public string Email { get; set; } = null!;

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;
    }
}
