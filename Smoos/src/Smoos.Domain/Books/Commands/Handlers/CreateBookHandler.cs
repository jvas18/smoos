using MediatR;
using Smoos.Domain.Books.Projections;
using Smoos.Domain.Books.ViewModels;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Common.Smoos.CrossCutting.Extensions;
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
        private IFileUtils _fileUtils;

        public CreateBookHandler(IBookRepository bookRepository, IFileUtils fileUtils)
        {
            _bookRepository = bookRepository;
            _fileUtils = fileUtils;
        }

        public async Task<BookVm> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            var book = new Book(Guid.NewGuid(), request.Name, request.ReleaseYear, request.Pages, request.Summary, request.Publisher, request.ArtistId);
            string imageUrl;
            if (request.Poster?.HasValue() == true)
            {
                if (!string.IsNullOrEmpty(book.Poster))
                    await _fileUtils.RemoveByUrlAsync(book.Poster);

                var fileName = $"books/{Guid.NewGuid()}{request.Poster.Name.GetExtension()}";

                imageUrl = await _fileUtils.UploadAsync(request.Poster, fileName);

                if (imageUrl.IsNull())
                    throw new Exception("Erro ao Importar o poster");
            }
            else
            {
                imageUrl = book.Poster;
            }
            book.Poster = imageUrl;
            await _bookRepository.AddAsync(book);
            return book.ToVm();
        }
    }

    public interface ICreateBookHandler: IRequestHandler<CreateBook, BookVm >
    {
    }
}
