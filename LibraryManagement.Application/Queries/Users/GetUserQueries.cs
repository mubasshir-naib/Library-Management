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
    public record GetUserQueries:IRequest<IEnumerable<UserEntity>>;
    public class GetUserQueriesHandler(IUserInterface userRepository)
        : IRequestHandler<GetUserQueries, IEnumerable<UserEntity>>
    {
        public async Task<IEnumerable<UserEntity>> Handle(GetUserQueries request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUserAsync();
        }
    }
}
