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
    public record UpdateUserCommand(Guid id,UserCreateDto dto):IRequest<UserEntity>;
    public class UpdateUserCommandHandler(IUserInterface userInterface)
        : IRequestHandler<UpdateUserCommand, UserEntity>
    {
        public async Task<UserEntity> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await userInterface.UpdateUserAsync(request.id, request.dto);
        }
    }
}
