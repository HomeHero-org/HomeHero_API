using HomeHero_API.Models;
using HomeHero_API.Models.Dto;
using HomeHero_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/passwordreset")]
[ApiController]
public class PasswordResetController : ControllerBase
{
    private readonly PasswordRecoveryService _passwordRecoveryService;

    public PasswordResetController(PasswordRecoveryService passwordRecoveryService)
    {
        _passwordRecoveryService = passwordRecoveryService;
    }

    // POST: api/passwordreset/request
    [HttpPost("request")]
    public async Task<IActionResult> RequestPasswordReset([FromBody] string email)
    {
        try
        {
            await _passwordRecoveryService.RequestPasswordReset(email);
            return Ok("Solicitud de restablecimiento de contraseña enviada correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST: api/passwordreset/setpassword
    [HttpPost("setpassword")]
    public async Task<IActionResult> SetPassword([FromBody] ResetPasswordDto model)
    {
        try
        {
            if (!await _passwordRecoveryService.ValidateCode(model.Email, model.Code))
            {
                return BadRequest("Código inválido o expirado.");
            }

            await _passwordRecoveryService.ChangePassword(model.Email, model.Code, model.NewPassword);
            return Ok("Contraseña actualizada correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}
