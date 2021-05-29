using MediatR;
using Smoos.Domain.Suggestions.Projections;
using Smoos.Domain.Suggestions.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Suggestions.Commands.Handlers
{
    public class CreateSuggestionHandler : IRequestHandler<CreateSuggestion, SuggestionVm>
    {
        private readonly ISuggestionRepository _suggestionRepository;

        public CreateSuggestionHandler(ISuggestionRepository suggestionRepository)
        {
            _suggestionRepository = suggestionRepository;
        }

        public async Task<SuggestionVm> Handle(CreateSuggestion request, CancellationToken cancellationToken)
        {

            var suggestion = await _suggestionRepository.AddAsync(new Suggestion( request.Name,request.UserId ,ECategory.Movie));
            return suggestion.ToVm();
        }
    }
}
