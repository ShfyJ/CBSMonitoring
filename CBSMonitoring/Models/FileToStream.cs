namespace CBSMonitoring.Models
{
    public class FileToStream
    {
        #nullable disable
        public Stream Memory { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }

        public FileToStream(Stream memory, string contentType, string fileName)
        {
            Memory = memory;
            ContentType = contentType;
            FileName = fileName;
        }
    }
}
