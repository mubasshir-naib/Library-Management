using LibraryManagement.Core.Dto.UserDto;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext dbContext,IFileService fileService):IUserInterface
    {
       private readonly IFileService _fileService = fileService;


        public async Task<UserEntity> AddUserAsync(UserCreateDto dto)
        {
            string avatar = await _fileService.SaveFileAsync(dto.Avatar, "covers", new[] { ".png", ".jpg" });

            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                UserName = dto.UserName,
                Avatar = avatar,
                CreationDate = DateTime.Now,
                Email = dto.Email,
                UserRoleEnum= dto.UserRoleEnum,
                UserStatusEnum=dto.UserStatusEnum,       
            };
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return user;
        }
        public async Task<IEnumerable<UserEntity>> GetUserAsync()
        {
            return await dbContext.Users.ToListAsync();
        }
        public async Task <UserEntity> GetUserByIdAsync(Guid id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("user not found!!!");
            }
            else return user;
        }
        public async Task<UserEntity>UpdateUserAsync(Guid id, UserCreateDto dto)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                throw new Exception("User Not found , Give the correct User Id !!!");

            }
            else
            {
               
                string avatar = await _fileService.SaveFileAsync(dto.Avatar, "covers", new[] { ".png", ".jpg" });
                user.UserName= dto.UserName;
                user.Email= dto.Email;
                user.Avatar = avatar;
                user.UserStatusEnum = dto.UserStatusEnum;
                user.UserRoleEnum = dto.UserRoleEnum;
                await dbContext.SaveChangesAsync();
                return user;

            }
        }
        public async Task<bool>DeleteUserAsync(Guid id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x=>x.Id == id);
            if(user == null)
            {
                return false;
            }
            else
            {
                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
