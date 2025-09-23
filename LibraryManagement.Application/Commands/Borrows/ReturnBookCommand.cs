using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.Borrows
{
    public record ReturnBookCommand(Guid requestId):IRequest<BorrowEntity>;
    public class ReturnBookCommandHandler(IBorrowBookRepository borrowBookRepository) : IRequestHandler<ReturnBookCommand, BorrowEntity>
    {
        public Task<BorrowEntity> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            return borrowBookRepository.ReturnBookStatus(request.requestId);
        }
    }

}
