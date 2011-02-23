using System.IO;

namespace JunkTrunk.Models
{
    public class BlobModel : FileItemModel
    {
        public Stream BlobFile { get; set; }
    }
}