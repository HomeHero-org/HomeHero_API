using HomeHero_API.Data;
using HomeHero_API.Models;
using HomeHero_API.Repository.IRepository;
using System;

namespace HomeHero_API.Repository
{
    public class PasswordRecoveryService
    {
        private readonly IPasswordResetRequestRepository _passwordReset;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private static Random _random = new Random();
        public PasswordRecoveryService(IPasswordResetRequestRepository passwordReset, IUserRepository userRepository, IEmailService emailService)
        {
            _passwordReset = passwordReset;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task RequestPasswordReset(string email)
        {
            var user = _userRepository.GetUser(email);
            if (user == null)
            {
                return;
            }

            var code = GenerateUniqueCode();
            var request = new PasswordResetRequest
            {
                UserId = user.UserId,
                Code = code,
                ExpiryDate = DateTime.Now.AddHours(1)
            };

            await _passwordReset.Create(request);

            var emailSubject = "Código de recuperación de contraseña";
            var emailBody = $"Estimado/a {user.NamesUser + user.SurnamesUser},\n\nTu código de recuperación de contraseña es: {code}. \nEste código expirará en 1 hora.\n\nSi no solicitaste este cambio, por favor ignora este mensaje.";

            await _emailService.SendEmailAsync(email, emailSubject, emailBody);
        }

        private string GenerateUniqueCode()
        {
            return _random.Next(100000, 1000000).ToString();
        }

        public async Task<bool> ValidateCode(string email, string code)
        {
            var user = _userRepository.GetUser(email);
            if (user == null)
            {
                return false;
            }

            var request = await _passwordReset.GetByCode(code);
            if (request == null || request.ExpiryDate < DateTime.Now || request.UserId != user.UserId)
            {
                return false;
            }

            return true;
        }

        public async Task ChangePassword(string email, string code, string newPassword)
        {
            var isValid = await ValidateCode(email, code);
            if (!isValid)
            {
                return;
            }

            var user = _userRepository.GetUser(email);
            await _userRepository.SetPassword(user, newPassword);

            var request = await _passwordReset.GetByCode(code);
            await _passwordReset.Delete(request);
        }

    }

}
