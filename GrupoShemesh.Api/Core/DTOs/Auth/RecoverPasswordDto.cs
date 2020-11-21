using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Core.DTOs.Auth
{
    public class RecoverPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
