namespace HomeHero_API.Repository.IRepository
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
