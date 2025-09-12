using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.User
{
    public class UpdateUserDto
    {
        // public string Username { get; set; } = null!;

        // public string Password { get; set; } = null!;

        // public string FullName { get; set; } = null!;

        // public string? Email { get; set; }

        // public string? PhoneNumber { get; set; }


        public string FullName { get; set; } = null!;

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public int? OrgId { get; set; }

        public int? UnitId { get; set; }

        public int? UserParent { get; set; }
        public string? Role { get; set; } = null!;

        public int? UnitUserId { get; set; }

        public int? PositionId { get; set; }

        public string? PositionName { get; set; }

    }
}