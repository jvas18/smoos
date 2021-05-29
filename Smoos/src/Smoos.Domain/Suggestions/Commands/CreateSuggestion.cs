using MediatR;
using Smoos.Domain.Suggestions.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Suggestions.Commands
{
    public class CreateSuggestion : IRequest<SuggestionVm>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public ECategory? Category { get; set; }
    }
}
