using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Core.Common
{
    public class AppConfig
    {
        public string Logger { get; set; }

        public string Domain { get; set; }

        public string BaseUrl { get; set; }

        public string AppUrl { get; set; }

        public bool RequireHttps { get; set; }
    }
}
