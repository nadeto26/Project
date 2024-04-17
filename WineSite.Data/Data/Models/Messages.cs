using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static WineSite.Data.Data.Common.Constants.Messeges;

namespace WineSite.Data.Data.Models
{
    [Comment("Contacts - Messages")]
    public class Messages
    {
        [Key]
        public int Id { get; set; }

        [Comment("Contact form - User Name")]
        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("Contact form - User Email")]
        [MaxLength(UserEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Comment("Contact form - User PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [Comment("Contact form - About the message")]
        [MaxLength(AboutMaxLength)]
        public string About { get; set; } = null!;

        [Comment("Contact form - Messege")]
        [MaxLength(MessegeMaxLength)]
        public string Message { get; set; } = null!;
    }
}
