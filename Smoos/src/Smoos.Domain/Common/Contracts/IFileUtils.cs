using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smoos.Domain.Common.Contracts
{
    public interface IFileUtils
    {
        Task<string> UploadAsync(FileInput file, string fileName, bool isPublic = true);
        Task<byte[]> DownloadAsync(string fileName, bool isPublic = true);
        Task<FileVm> DownloadAsFileResultVmByUrlAsync(string fileName);
        Task<string> GetAuthUrlFileAsync(Uri sasUri);
        Task<bool> RemoveByUrlAsync(string url);
    }
}
