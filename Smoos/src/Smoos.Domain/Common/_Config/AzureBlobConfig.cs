using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Common._Config
{
	public class AzureBlobConfig
	{
		public string Key { get; set; }

		public string ConnectionString { get; set; }

		public string Container { get; set; }

		public string PrivateContainer { get; set; }
	}
}
