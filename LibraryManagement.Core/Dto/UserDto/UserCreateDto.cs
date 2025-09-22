using LibraryManagement.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Dto.UserDto
{
    public class UserCreateDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IFormFile? Avatar { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public UserRole UserRoleEnum { get; set; } = UserRole.User;
        public UserStatus UserStatusEnum { get; set; } = UserStatus.InActive;
    }
}
