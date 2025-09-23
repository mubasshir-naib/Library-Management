using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Users
{
    public record  GetUserByIdQuery(Guid Id):IRequest<UserEntity>;
    public class GetUserByIdHandler(IUserInterface userInterface)
        : IRequestHandler<GetUserByIdQuery, UserEntity>
    {
        public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await userInterface.GetUserByIdAsync(request.Id);
        }
    }
}
