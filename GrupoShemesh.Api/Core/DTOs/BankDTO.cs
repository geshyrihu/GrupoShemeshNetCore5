using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Api.Core.DTOs
{
    public class BankDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        public string code { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        public string shortName { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        public string LargeName { get; set; }
    }
    public class BankAddOrEditDTO
    {

        [Required(ErrorMessage = "Campo {0} requerido")]
        public string code { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        public string shortName { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        public string LargeName { get; set; }
    }
}
