namespace HomeHero_API.Models
{
    public class PasswordResetRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
