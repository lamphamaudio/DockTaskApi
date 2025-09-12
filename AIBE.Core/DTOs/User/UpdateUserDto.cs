using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.User
{
    public class UpdateUserDto
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

    }
}