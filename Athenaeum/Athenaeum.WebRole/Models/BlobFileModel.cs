using System;
using System.IO;

namespace Athenaeum.WebRole.Models
{
    public class BlobFileModel
    {
        public Stream BlobFile { get; set; }
        public string FileName { get; set; }
        public DateTime DownloadedOn { get; set; }
        public string Description { get; set; }
    }
}