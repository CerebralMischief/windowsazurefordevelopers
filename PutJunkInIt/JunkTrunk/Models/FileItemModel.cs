using System;

namespace JunkTrunk.Models
{
    public class FileItemModel
    {
        public string FileName { get; set; }
        public DateTime DownloadedOn { get; set; }
        public string Description { get; set; }
    }
}