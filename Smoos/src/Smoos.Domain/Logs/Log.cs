using Smoos.Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Smoos.Domain.Logs
{
    public class Log : IEntityType<Guid>
    {
        public Guid Id { get; set; }

        public DateTime? OccurredAt { get; set; }

        public string Level { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

    }
}
