using LibraryManagement.Core.Dto.UserDto;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.Users
{
    public record AddUserCommand(UserCreateDto user) : IRequest<UserEntity>;
    public class AddUserCommandHandler(IUserInterface userInterface)
        : IRequestHandler<AddUserCommand, UserEntity>
    {
        public async Task<UserEntity> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await userInterface.AddUserAsync(request.user);
        }
    }
}
