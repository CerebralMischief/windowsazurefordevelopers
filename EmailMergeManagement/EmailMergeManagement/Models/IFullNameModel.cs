namespace EmailMergeManagement.Models
{
    public interface IFullNameModel
    {
        string First { get; set; }
        string Last { get; set; }
        SexOfName SexOfName { get; set; }
    }
}