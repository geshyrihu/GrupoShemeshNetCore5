using Microsoft.Extensions.Configuration;
using GrupoShemesh.Core.DTOs.Auth;
using GrupoShemesh.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using GrupoShemesh.Infrastructure.Services;

namespace GrupoShemesh.Api.Helpers
{
    public interface IAuthRepository
    {
        Task SendMailRecoverPassword(ApplicationUser user);
        Task<ApplicationUser> ValidateUser(string email);
        Task<IdentityResult> Create(LoginDto dto);
        Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);
        Task<IList<string>> GetRolesAsync(string email);
        Task<SignInResult> Login(LoginDto dto);
        Task<UserTokenDto> BuildToken(LoginDto dto, IList<string> roles);
        Task<UserTokenDto> ValidateJwtToken(ValidateToken token);


    }

    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMailRepository _mailRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthRepository(IConfiguration configuration,
                              IHttpContextAccessor httpContextAccessor,
                              IMailRepository mailRepository,
                              SignInManager<ApplicationUser> signInManager,
                              UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _mailRepository = mailRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Create(LoginDto dto)
        {

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = "",
                LastName = "",
                Birth = DateTime.Now.AddYears(-18),
                PhoneNumber = "",
                ProfessionId = 1,
                CustomerId = 1,
                PhotoPath = "avatar.png",
            };
            return await _userManager.CreateAsync(user, dto.Password);
        }

        // UserTokenDto
        public async Task<UserTokenDto> BuildToken(LoginDto dto, IList<string> roles)
        {
            var claims = new List<Claim>
            {
               new Claim(JwtRegisteredClaimNames.UniqueName, dto.Email),
               new Claim("miValor", "Lo que yo quiera"),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Tiempo de expiración del token. En nuestro caso lo hacemos de una hora.
            var expiration = DateTime.UtcNow.AddHours(12);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
            var user = await _userManager.Users.Include(x => x.Profession)
                                               .Include(x => x.Customer)
                                               .FirstOrDefaultAsync(x => x.Email == dto.Email);

            return new UserTokenDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                InfoUserAuthDto = new InfoUserAuthDto(user.Id,
                                                      user.PhoneNumber,
                                                      user.Email,
                                                      user.FirstName,
                                                      user.LastName,
                                                      user.Birth.ToString("yyyy-MM-dd"),
                                                      user.PhotoPath,
                                                      user.Profession.NameProfession,
                                                      user.Customer.NameCustomer,
                                                      user.CustomerId,
                                                      await _userManager.GetRolesAsync(user)),
            };
        }

        public async Task<SignInResult> Login(LoginDto dto)
        {
            return await _signInManager.PasswordSignInAsync(dto.Email,
                                                     dto.Password,
                                                     isPersistent: false,
                                                     lockoutOnFailure: false);
        }

        public async Task<IList<string>> GetRolesAsync(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(usuario);
            return roles;
        }

        public async Task<ApplicationUser> ValidateUser(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task SendMailRecoverPassword(ApplicationUser user)
        {
            var myToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            myToken = myToken.Replace("+", ".");

            var rutaAngular = "http://localhost:4200/#/auth/resetpassword";
            var link = $"{rutaAngular}?token={myToken}";

            _mailRepository.SendMail(user.Email, "Recuperar contraseña", $"<h1>Recuperar contraseña</h1>" +
              $"Para restablecer la contraseña, haga clic en este enlace:</br></br>" +
              $"<a href = \"{link}\">Recuperar contraseña</a>");
        }

        public async Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword)
        {
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public async Task<UserTokenDto> ValidateJwtToken(ValidateToken token)
        {
            var model = new LoginDto();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:key"]);
            try
            {
                tokenHandler.ValidateToken(token.Token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var claims = "";

                foreach (var item in jwtToken.Claims)
                {
                    if (item.Type == "unique_name")
                    {
                        claims = item.Value;
                    }
                }

                model.Email = claims;
                model.Password = "";
                var result = await BuildToken(model, new List<string>());
                return result;
            }
            catch
            {
                return new UserTokenDto();
            }
        }
    }
}
