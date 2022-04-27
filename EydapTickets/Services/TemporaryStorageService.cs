using System.Configuration;
using Storage.Net;

namespace EydapTickets.Services
{
    public class TemporaryStorageService : BlobStorageServiceBase
    {
        public TemporaryStorageService(string folderPath)
            : base(StorageFactory.Blobs.FromConnectionString(
                ConfigurationManager.ConnectionStrings["TemporaryStorage"].ConnectionString), folderPath)
        {
            //NOOP
        }
    }
}