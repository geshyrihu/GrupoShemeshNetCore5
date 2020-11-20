using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Core.DTOs.Auth;
using GrupoShemesh.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<UserTokenDto>> Create([FromBody] LoginDto dto)
        {
            var result = await _authRepository.Create(dto);
            if (result.Succeeded)
            {
                return await _authRepository.BuildToken(dto, new List<string>());
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserTokenDto>> Login([FromBody] LoginDto dto)
        {
            var result = await _authRepository.Login(dto);
            if (result.Succeeded)
            {
                var roles = await _authRepository.GetRolesAsync(dto.Email);
                return await _authRepository.BuildToken(dto, roles);
            }
            else
            {
                var error = new IdentityError()
                {
                    Code = "Error",
                    Description = "Email o Password invalido"
                };
                //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(error);
            }
        }

        [HttpGet("ValidateUser/{email}")]
        public async Task<ActionResult<ApplicationUser>> ValidateUser(string email)
        {
            var user = await _authRepository.ValidateUser(email);
            return Ok(user);
        }

        [HttpPost("RecoverPassword")]
        public async Task<ActionResult> RecoverPassword([FromBody] RecoverPasswordDto dto)
        {
            var user = await _authRepository.ValidateUser(dto.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "El correo electrónico no corresponde a un usuario registrado..");
                return NotFound(ModelState);
            }
            await _authRepository.SendMailRecoverPassword(user);
            return Ok();
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var user = await _authRepository.ValidateUser(dto.Email);
            string message;
            if (user != null)
            {
                dto.Token = dto.Token.Replace(".", "+");
                var result = await _authRepository.ResetPasswordAsync(user, dto.Token, dto.Password);
                if (result.Succeeded)
                {
                    message = "Restablecimiento de contraseña exitosa.";
                    return NoContent();
                }
                else
                {
                    message = "Error al restablecer la contraseña.";
                    return NotFound(message);
                }
            }
            message = "Usuario no encontrado.";
            return NotFound(message);
        }

        [HttpPost("ValidateJwtToken")]
        public async Task<ActionResult<UserTokenDto>> ValidateJwtToken([FromBody] ValidateToken token)
        {
            if (token.Token != null)
            {
                var vailidation = await _authRepository.ValidateJwtToken(token);
                return vailidation;
            }
            return new UserTokenDto();
        }
    }
}
