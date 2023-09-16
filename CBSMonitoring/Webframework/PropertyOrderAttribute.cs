namespace CBSMonitoring.Webframework
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyOrderAttribute : Attribute
    {
        public int Order { get; private set; }
        public PropertyOrderAttribute(int order)
        {
            Order = order;
        }
    }
}
