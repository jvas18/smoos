using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Common
{
	public class FileVm : BaseVm
	{
		public byte[] Buffer { get; set; }
		public string ContentType { get; set; }
		public string FileName { get; set; }
	}

	public class BaseVm
	{
		public Guid? Id { get; set; }

		public DateTime? CreatedAt { get; set; }

		public bool? Deleted { get; set; }

		public object Clone() => this.MemberwiseClone();
	}
}
