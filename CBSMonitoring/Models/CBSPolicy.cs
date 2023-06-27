namespace CBSMonitoring.Models
{
    public class CBSPolicy : OrgMonitoring
    {
        public bool HasPolicy { get; set; }
        public ICollection<FileModel> Files { get; set; }

    }
}
