using Microsoft.AspNetCore.Identity;

namespace GrupoShemesh.Api.Helpers
{
    public class MyErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "Las contraseñas deben tener al menos un carácter no alfanumérico."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordRequiresLower),
                Description = "Las contraseñas deben tener al menos una minúscula ('a' - 'z')."
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "Las contraseñas deben tener al menos una mayúscula ('A' - 'Z')."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordRequiresDigit),
                Description = "Las contraseñas deben tener al menos un dígito('0' - '9').."
            };
        }

        public override IdentityError InvalidEmail(string email)

        {
            return new IdentityError()
            {
                Code = nameof(InvalidEmail),
                Description = "Dirección de correo electronico no valida"
            };
        }

        public override IdentityError DuplicateUserName(string userName)

        {
            return new IdentityError()
            {
                Code = nameof(DuplicateUserName),
                Description = "El nombre de usuario " + userName + " ya está en uso."
            };
        }
    }
}
