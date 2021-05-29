using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smoos.Domain.Common;
using Smoos.Domain.Common._Config;
using Smoos.Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoos.Api._Config
{
	public static class AzureStorageServiceConfig
	{
		public static IServiceCollection AppAddAzureStorageService(this IServiceCollection services, IConfiguration config)
		{
			var azureBlobConfig = new AzureBlobConfig();

			config.GetSection(nameof(AzureBlobConfig)).Bind(azureBlobConfig);

			services.AddSingleton(azureBlobConfig);

			services.AddSingleton<IFileUtils, FileUtils>();

			return services;
		}
	}
}
