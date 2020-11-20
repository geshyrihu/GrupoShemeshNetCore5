using Administration.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoShemesh.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateCreation { get; set; } = DateTime.Now;

        [Display(Name = "Empleado Activo")]
        public bool Active { get; set; } = true;

        [Required(ErrorMessage = "*")]
        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        [StringLength(60, ErrorMessage = "Caracteres minimos {2}, y maximo {1} ", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Apellidos")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birth { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "*")]
        [Display(Name = "Salario")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public double Salary { get; set; } = 0.00;

        [Required(ErrorMessage = "*")]
        [Display(Name = "Tipo de Empleado")]
        public ETypeContract? TypeContract { get; set; }

        [Display(Name = "Foto")]
        public string PhotoPath { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Curp")]
        public string Curp { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "NSS")]
        public string NSS { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Sexo")]
        public ESex? Sex { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdmission { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "*")]
        [Display(Name = "Dirección")]
        [DataType(DataType.MultilineText)]
        [MaxLength(255, ErrorMessage = "Maximo {1}caracteres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Télefono Celular")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Télefono Local")]
        [DataType(DataType.PhoneNumber)]
        public string LocalPhone { get; set; }

        //Relaciones
        [Required(ErrorMessage = "*")]
        [Display(Name = "Tipo de Sangre")]
        public EBloodType? BloodType { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Nacionalidad")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Estado Civil")]
        public EMaritalStatus? MaritalStatus { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Nivel de Educación")]
        public EEducationLevel? EducationLevel { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Area")]
        public EArea? Area { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Profesión")]
        public int ProfessionId { get; set; }
        public virtual Profession Profession { get; set; }

        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<ContactEmployee> ContactsEmployees { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Nombre Completo")]
        public string FullName => $"{Name} {LastName}";
    }
}
