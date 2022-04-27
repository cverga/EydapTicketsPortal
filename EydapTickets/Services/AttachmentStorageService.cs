using System.Configuration;
using Storage.Net;

namespace EydapTickets.Services
{
    public class AttachmentStorageService: BlobStorageServiceBase
    {
        public AttachmentStorageService(string folderPath)
            : base(StorageFactory.Blobs.FromConnectionString(
                ConfigurationManager.ConnectionStrings["AttachmentStorage"].ConnectionString), folderPath)
        {
            //NOOP
        }
    }
}