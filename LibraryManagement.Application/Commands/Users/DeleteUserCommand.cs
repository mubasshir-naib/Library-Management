using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.Users
{
    public record DeleteUserCommand(Guid id):IRequest<bool>;
    public class DeleteUserHandler(IUserInterface userInterface)
        : IRequestHandler<DeleteUserCommand, bool>
    {
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await userInterface.DeleteUserAsync(request.id);
        }
    }
}
