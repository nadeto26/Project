using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WineSite.Data.Data.Common.Constants.Messeges;

namespace WineSite.Core.Models.Contact
{
    public class AddMessage
    {
        public int Id { get; set; }

        [MaxLength(UserNameMaxLength)]
        [MinLength(UserNameMinLength)]
        public string Name { get; set; } = null!;

        [MaxLength(UserEmailMaxLength)]
        [MinLength(UserEmailMinLength)]
        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        [MaxLength(AboutMaxLength)]
        [MinLength(AboutMinLength)]
        public string About { get; set; } = null!;

        [MaxLength(MessegeMaxLength)]
        [MinLength(MessegeMinLength)]
        public string Message { get; set; } = null!;
    }
}
