using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        public string NameCustomer { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Teléfono 1")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneOne { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Teléfono 2")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneTwo { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(255, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        public string Adreess { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Register { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "¿Cliente Activo?")]
        public bool Active { get; set; } = true;

        [Display(Name = "Logo")]
        public string PhotoPath { get; set; }


    }
}
