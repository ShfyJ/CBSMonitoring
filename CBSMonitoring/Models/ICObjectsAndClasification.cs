namespace CBSMonitoring.Models
{
    public class ICObjectsAndClasification : OrgMonitoring      //2.3
    {
        public bool IsListOfProtectedObjAvailable { get; set; }
        public bool IsObjectsClasified { get; set; }
        public bool IsISystemAvailable { get; set; }
        public bool IsISystemResourcesAvailable { get; set; }
        #nullable disable
        public ICollection<FileModel> Files{ get; set; }
    }
}
