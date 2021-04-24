using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smoos.Domain.Books;
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
        public async Task<IActionResult> Post([FromBody] CreateMovie command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }
    }
}
