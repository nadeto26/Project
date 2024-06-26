﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static WineSite.Data.Data.Common.Constants.ApplicationUser;
namespace WineSite.Data.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; } = null!;
    }
}
