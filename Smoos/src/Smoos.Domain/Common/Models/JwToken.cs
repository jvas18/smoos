using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Common.Models
{
    public class JwToken
    {
        public DateTime? NotBefore { get; set; }

        public DateTime? ExpiresIn { get; set; }

        public string AccessToken { get; set; }
    }
}
