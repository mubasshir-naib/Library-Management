using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.Borrows
{
    public record ChangeBorrowBookStatusCommand(Guid requestId,BorrowRequestStatus status):IRequest<BorrowEntity>;
    public class ChangeBorrowBookStatusCommandHandler(IBorrowBookRepository borrowBookRepository) : IRequestHandler<ChangeBorrowBookStatusCommand, BorrowEntity>
    {
        public async Task<BorrowEntity> Handle(ChangeBorrowBookStatusCommand request, CancellationToken cancellationToken)
        {
            return await borrowBookRepository.ChangeBorrowBookStatus(request.requestId,request.status);
        }
    }


}
