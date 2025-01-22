namespace CBSMonitoring.Services
{
    public class PasswordService : IPasswordService
    {
        public string CheckPasswordStrength(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return "Password cannot be empty.";

            int score = 0;

            if (password.Length >= 12) score++;
            if (password.Length >= 8) score++;
            if (HasMixedCase(password)) score++;
            if (password.Any(char.IsDigit)) score++;
            if (password.Any(ch => !char.IsLetterOrDigit(ch))) score++;

            if (score < 3) return "Weak Password";
            if (score < 4) return "Medium Password";
            return "Strong Password";
        }

        private bool HasMixedCase(string password)
        {
            return password.Any(char.IsUpper) && password.Any(char.IsLower);
        }
    }
    
}
