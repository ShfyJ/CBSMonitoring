namespace CBSMonitoring.DTOs
{
    public class ValidationError
    {
        #nullable disable
        public string MemberName { get; init; }
        public string ErrorMessage { get; init; }

        public ValidationError(string memberName, string errorMessage)
        {
            MemberName = memberName;
            ErrorMessage = errorMessage;
        }
    }
}
