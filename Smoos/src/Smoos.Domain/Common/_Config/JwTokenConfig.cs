using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Common._Config
{
    public class JwTokenConfig
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpirationHours { get; set; }
    }
}
