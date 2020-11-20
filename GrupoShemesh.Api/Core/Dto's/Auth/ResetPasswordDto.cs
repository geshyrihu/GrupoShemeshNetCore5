using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Core.DTOs.Auth
{
    public class ResetPasswordDto
    {
        [Required(ErrorMessage = "*")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Nueva contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
