using System.IO;

namespace StorageTrunk.Web.Models
{
public class BlobModel : FileItemModel
{
    public Stream BlobFile { get; set; }
}
}