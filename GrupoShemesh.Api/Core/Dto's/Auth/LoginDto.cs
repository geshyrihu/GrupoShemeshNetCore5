using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Core.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Password { get; set; }
    }
}
