using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class Provider
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Razón Social")]
        public string NameProvider { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "RFC")]
        public string Rfc { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Dirección")]
        [DataType(DataType.MultilineText)]
        [MaxLength(255, ErrorMessage = "Maximo {1}caracteres")]
        public string Address { get; set; }

        [Display(Name = "Logo")]
        public string PathPhoto { get; set; }

        [Display(Name = "Ventas")]
        public bool Sales { get; set; }

        [Display(Name = "Reparación")]
        public bool Repair { get; set; }

        [Display(Name = "Télefono 1")]
        [DataType(DataType.PhoneNumber)]
        public string phoneOne { get; set; }

        [Display(Name = "Télefono 2")]
        [DataType(DataType.PhoneNumber)]
        public string phoneTwo { get; set; }

        [Display(Name = "Página Web")]
        public string WebPage { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Contacto 1")]
        public string ContactOne { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Puesto")]
        public string PositionOne { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Celular")]
        public string CellPhoneOne { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string EmailOne { get; set; }


        [Display(Name = "Contacto 2")]
        public string ContactTwo { get; set; }
        [Display(Name = "Puesto ")]
        public string PositionTwo { get; set; }
        [Display(Name = "Celular")]
        public string CellPhoneTwo { get; set; }

        [Display(Name = "Email")]
        public string EmailTwo { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Cheque a nombre de:")]
        public string NameCheck { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Banco")]
        public int BankId { get; set; }
        public virtual Bank bank { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "N° de Cuenta")]
        public string PaymentAccount { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Clave Interbancaria")]
        public string InterbankCode { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
