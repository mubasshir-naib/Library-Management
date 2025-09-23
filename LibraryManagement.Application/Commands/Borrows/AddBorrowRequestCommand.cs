using LibraryManagement.Core.DTOs;
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
    public record AddBorrowRequestCommand(BorrowRequestDTO borrowRequest):IRequest<BorrowEntity>;

    public class AddBorrowRequestCommandHandler(IBorrowBookRepository borrowBookRepository) : IRequestHandler<AddBorrowRequestCommand, BorrowEntity>
    {
        public async Task<BorrowEntity> Handle(AddBorrowRequestCommand request, CancellationToken cancellationToken)
        {
            return await borrowBookRepository.BorrowBookRequest(request.borrowRequest);
        }
    }
}
