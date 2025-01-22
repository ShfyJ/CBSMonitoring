namespace CBSMonitoring.Services
{
    public interface IPasswordService
    {
        string CheckPasswordStrength(string password);
    }
}
