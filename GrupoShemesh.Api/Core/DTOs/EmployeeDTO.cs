using Administration.Enum;
using Microsoft.AspNetCore.Http;
using System;

namespace GrupoShemesh.Api.Core.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public bool Active { get; set; } = true;
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public double Salary { get; set; }
        public ETypeContract? TypeContract { get; set; }
        public string PhotoPath { get; set; }
        public string Curp { get; set; }
        public string RFC { get; set; }
        public string NSS { get; set; }
        public ESex? Sex { get; set; }
        public DateTime DateAdmission { get; set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }
        public string LocalPhone { get; set; }
        public EBloodType? BloodType { get; set; }
        public string Nationality { get; set; }
        public EMaritalStatus? MaritalStatus { get; set; }
        public EEducationLevel? EducationLevel { get; set; }
        public EArea? Area { get; set; }
        public int ProfessionId { get; set; }
        public int CustomerId { get; set; }

    }
    public class EmployeeAddOrEditDTO
    {
        public DateTime? DateCreation { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public double Salary { get; set; } = 0.00;
        public ETypeContract? TypeContract { get; set; }
        public IFormFile PhotoPath { get; set; }
        public string Curp { get; set; }
        public string RFC { get; set; }
        public string NSS { get; set; }
        public ESex? Sex { get; set; }
        public DateTime DateAdmission { get; set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }
        public string LocalPhone { get; set; }
        public EBloodType? BloodType { get; set; }
        public string Nationality { get; set; }
        public EMaritalStatus? MaritalStatus { get; set; }
        public EEducationLevel? EducationLevel { get; set; }
        public EArea? Area { get; set; }
        public int ProfessionId { get; set; }
        public int CustomerId { get; set; }
    }
}
