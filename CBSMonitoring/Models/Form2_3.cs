namespace CBSMonitoring.Models
{
    public class Form2_3 : OrgMonitoring      //2.3
    {
        public bool? IsListOfProtectedObjAvailable { get; set; }
        public bool? IsObjectsClasified { get; set; }
        public bool? IsISystemAvailable { get; set; }
        public bool? IsISystemResourcesAvailable { get; set; }
        public ICollection<FileModel>? Files{ get; set; }
    }
}
