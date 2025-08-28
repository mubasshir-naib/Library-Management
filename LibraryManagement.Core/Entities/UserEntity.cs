using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Core.Enums;

namespace LibraryManagement.Core.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Avatar { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public UserRole UserRoleEnum { get; set; } = UserRole.User;
        public UserStatus UserStatusEnum { get; set; } = UserStatus.InActive;

    }

}

