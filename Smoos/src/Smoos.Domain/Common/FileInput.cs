using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Smoos.Domain.Common
{
    public class FileInput
    {
        [Required]
        public byte[] Buffer { get; set; }

        [Required]
        public string Name { get; set; }

        public bool HasValue() => Buffer?.Length > 0;
    }
}
