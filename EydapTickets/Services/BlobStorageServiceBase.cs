using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Storage.Net;
using Storage.Net.Blob;

namespace EydapTickets.Services
{
    public abstract class BlobStorageServiceBase
    {
        private IBlobStorage Storage { get; }

        private string FolderPath { get; }

        protected BlobStorageServiceBase(IBlobStorage storage, string folderPath)
        {
            if (storage == null)
            {
                throw new ArgumentNullException(nameof(storage));
            }

            Storage = storage;
            FolderPath = folderPath;
        }

        public async Task<IReadOnlyCollection<BlobId>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var options = new ListOptions
            {
                FolderPath = FolderPath
            };

            return await Storage.ListAsync(options, cancellationToken);
        }

        public async Task DeleteAsync(string fileName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var blobId = GetBlobId(fileName);
            await Storage.DeleteAsync(blobId, cancellationToken);
        }

        public async Task WriteAsync(string fileName, Stream stream, bool append = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            var blobId = GetBlobId(fileName);
            await Storage.WriteAsync(blobId, stream, append, cancellationToken);
        }

        public async Task CopyToAsync(string fileName, BlobStorageServiceBase targetStorage, CancellationToken cancellationToken = default(CancellationToken))
        {
            var blobId = GetBlobId(fileName);
            using (var sourceStream = await Storage.OpenReadAsync(blobId, cancellationToken))
            {
                await targetStorage.WriteAsync(fileName, sourceStream, false, cancellationToken);
            }
        }

        public async Task MoveToAsync(string fileName, BlobStorageServiceBase targetStorage, CancellationToken cancellationToken = default(CancellationToken))
        {
            await CopyToAsync(fileName, targetStorage, cancellationToken);
            if (await targetStorage.ExistsAsync(fileName, cancellationToken))
            {
                await DeleteAsync(fileName, cancellationToken);
            }
        }

        public async Task<byte[]> ReadAllBytes(string fileName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var blobId = GetBlobId(fileName);
            using (var storageStream = await Storage.OpenReadAsync(blobId, cancellationToken))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await storageStream.CopyToAsync(memoryStream, 81920, cancellationToken);
                    return memoryStream.ToArray();
                }
            }
        }

        public async Task<bool> ExistsAsync(string fileName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var blobId = GetBlobId(fileName);
            return await Storage.ExistsAsync(blobId, cancellationToken);
        }

        protected string GetBlobId(string fileName)
        {
            return StoragePath.Combine(FolderPath, fileName);
        }
    }
}