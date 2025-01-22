namespace CBSMonitoring.Models
{
    public class BlacklistedToken
    {
        public int Id { get; set; }
        public string Jti { get; set; } // JWT ID
        public DateTime Expiration { get; set; }
    }
}
