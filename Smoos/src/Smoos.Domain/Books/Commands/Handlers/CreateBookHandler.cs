using MediatR;
using Smoos.Domain.Books.Projections;
using Smoos.Domain.Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Books.Commands.Handlers
{
    public class CreateBookHandler : ICreateBookHandler
    {
        private IBookRepository _bookRepository;

        public CreateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookVm> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.AddAsync(new Book(Guid.NewGuid(), request.Name, request.ReleaseYear, request.Pages, request.Summary, request.Publisher, request.ArtistId));
            return book.ToVm();
        }
    }

    public interface ICreateBookHandler: IRequestHandler<CreateBook, BookVm >
    {
    }
}
