using LibraryManagement.Core.Dto.UserDto;
using LibraryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Interfaces
{
    public interface IUserInterface
    {
        Task<UserEntity> AddUserAsync(UserCreateDto dto);
        Task<IEnumerable<UserEntity>> GetUserAsync();
        Task<UserEntity> GetUserByIdAsync(Guid Id);
        Task<UserEntity>UpdateUserAsync(Guid Id, UserCreateDto dto);
        Task<bool> DeleteUserAsync(Guid Id);
    }
}
