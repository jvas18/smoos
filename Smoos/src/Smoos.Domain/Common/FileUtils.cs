using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using Smoos.Domain.Common._Config;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Common.Smoos.CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Common
{
    public class FileUtils: IFileUtils
    {

        private readonly AzureBlobConfig _config;

        public FileUtils(AzureBlobConfig config)
        {
            _config = config;
        }

        public async Task<string> UploadAsync(FileInput logo, string fileName, bool isPublic = false)
        {
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out var contentType);

            if (!CloudStorageAccount.TryParse(_config.ConnectionString, out var account)) return null;

            var client = account.CreateCloudBlobClient();

            var container = client.GetContainerReference("demo");

            if (!container.Exists()) return null;

            var blob = container.GetBlockBlobReference(fileName);

            using (var ms = new MemoryStream(logo.Buffer))
            {
                blob.Properties.ContentType = contentType ?? fileName.HandleContentType();

                await blob.UploadFromStreamAsync(new MemoryStream(logo.Buffer));
                return blob.Uri.ToString();
            }
        }

        public async Task<byte[]> DownloadAsync(string fileName, bool isPublic = true)
        {
            if (!CloudStorageAccount.TryParse(_config.ConnectionString, out var account)) return null;

            var client = account.CreateCloudBlobClient();

            var container = client.GetContainerReference(isPublic ? _config.Container : _config.PrivateContainer);

            if (!container.Exists()) return null;

            var blob = container.GetBlockBlobReference(fileName);

            using (var ms = new MemoryStream())
            {
                await blob.DownloadToStreamAsync(ms);
                return ms.ToArray();
            }
        }

        public async Task<FileVm> DownloadAsFileResultVmByUrlAsync(string url)
        {
            if (!CloudStorageAccount.TryParse(_config.ConnectionString, out var account)) return null;

            var accountName = CloudStorageAccount.Parse(_config.ConnectionString);
            var blob = new CloudBlockBlob(new Uri(url), credentials: new StorageCredentials(accountName.Credentials.AccountName, _config.Key));

            using (var ms = new MemoryStream())
            {
                await blob.DownloadToStreamAsync(ms);
                return new FileVm
                {
                    Buffer = ms.ToArray(),
                    ContentType = blob.Properties.ContentType,
                    FileName = string.Empty
                };
            }
        }

        public async Task<string> GetAuthUrlFileAsync(Uri sasUri)
        {
            var accountName = CloudStorageAccount.Parse(_config.ConnectionString);
            var cloudBlockBlob = new CloudBlockBlob(sasUri, credentials: new StorageCredentials(accountName.Credentials.AccountName, _config.Key));
            var sharedAccessBlobPolicy = new SharedAccessBlobPolicy
            {
                SharedAccessExpiryTime = DateTimeOffset.Now.AddHours(24),
                Permissions = SharedAccessBlobPermissions.Read
            };

            var sharedAcessSignature = cloudBlockBlob.GetSharedAccessSignature(sharedAccessBlobPolicy);
            return await Task.FromResult(cloudBlockBlob.Uri + sharedAcessSignature);
        }

        public async Task<bool> RemoveByUrlAsync(string url)
        {
            if (!CloudStorageAccount.TryParse(_config.ConnectionString, out var account)) return false;

            var blob = new CloudBlockBlob(new Uri(url), account.Credentials);

            await blob.DeleteAsync(CancellationToken.None);

            return true;
        }
    }
}
