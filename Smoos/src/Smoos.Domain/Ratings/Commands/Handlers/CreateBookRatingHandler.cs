using MediatR;
using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Books;
using Smoos.Domain.Ratings.Projections;
using Smoos.Domain.Ratings.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Ratings.Commands.Handlers
{
    public class CreateBookRatingHandler : IRequestHandler<CreateBookRating, RatingVm>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IBookRepository _bookRepository;

        public CreateBookRatingHandler(IRatingRepository ratingRepository, IBookRepository bookRepository)
        {
            _ratingRepository = ratingRepository;
            _bookRepository = bookRepository;
        }

        public async Task<RatingVm> Handle(CreateBookRating request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.AddAsync(new Rating(request.Comment, request.Stars, request.UserId,request.Title,null ,request.BookId));
            var book = await _bookRepository.ListAsNoTracking().Include(x=>x.Ratings).FirstOrDefaultAsync(x => x.Id == request.BookId);

            return rating.ToVm();
        }
    }
}
