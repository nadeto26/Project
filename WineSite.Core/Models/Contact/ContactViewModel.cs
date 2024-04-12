using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineSite.Core.Models.Contact
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string About { get; set; } = null!;

        public string Message { get; set; } = null!;
    }
}
