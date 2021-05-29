using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Books;
using Smoos.Domain.Books.Commands;
using Smoos.Domain.Books.Projections;
using Smoos.Domain.Movies.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoos.Api.Controllers
{
    [Route("/books")]
    [ApiController]
    public class BooksController: ControllerBase
    {
        private readonly IBookRepository _booksRepository;
        private readonly IMediator _mediator;

        public BooksController(IBookRepository booksRepository, IMediator mediator)
        {
            _booksRepository = booksRepository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBook command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(Ok(_booksRepository.ListAsNoTracking().ToVm()));
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await Task.FromResult(Ok((_booksRepository.ListAsNoTracking(x => x.Id == id).Include(x => x.Ratings).Include(x => x.Author).ToVm().FirstOrDefault())));
        }
    }
}
