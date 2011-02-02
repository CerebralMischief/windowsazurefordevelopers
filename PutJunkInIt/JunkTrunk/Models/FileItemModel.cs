using System;

namespace JunkTrunk.Models
{
    public class FileItemModel
    {
        public Guid ResourceId { get; set; }
        public string ResourceLocation { get; set; }
        public DateTime UploadedOn { get; set; }
    }
}