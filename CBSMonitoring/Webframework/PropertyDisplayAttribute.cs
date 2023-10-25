namespace CBSMonitoring.Webframework
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyDisplayAttribute : Attribute
    {
        public bool Display { get; private set; }
        public PropertyDisplayAttribute(bool display)
        {
            Display = display;
        }
    }
}
