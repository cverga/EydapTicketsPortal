namespace EydapTickets.Models
{
    public class FileAttachment
    {
        public FileAttachment()
        {
            // NOOP
        }

        public FileAttachment(
            string uniqueId,
            string appTag,
            string appFileId,
            string fileName,
            string fileDirectory,
            string fileSize,
            string creationDate)
        {
            UniqueId = uniqueId;
            AppTag = appTag;
            AppFileID = appFileId;
            FileName = fileName;
            FileDirectory = fileDirectory;
            FileSize = fileSize;
            CreationDate = creationDate;
        }

        public string UniqueId { get; set; }

        public string AppTag { get; set; }

        public string AppFileID { get; set; }

        public string FileName { get; set; }

        public string FileDirectory { get; set; }

        public string FileSize { get; set; }

        public string CreationDate { get; set; }
    }
}