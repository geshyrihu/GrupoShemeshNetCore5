using Microsoft.AspNetCore.Http;
using System;

namespace GrupoShemesh.Api.Core.DTOs
{
    public class CustomerGetDto
    {
        public int Id { get; set; }
        public string NameCustomer { get; set; }
        public string RFC { get; set; }
        public string PhoneOne { get; set; }
        public string PhoneTwo { get; set; }
        public string Adreess { get; set; }
        public DateTime Register { get; set; } 
        public string Active { get; set; }
        public string PhotoPath { get; set; }
    }

    public class CustomerAddOrEditDto
    {
        public string NameCustomer { get; set; }
        public string RFC { get; set; }
        public string PhoneOne { get; set; }
        public string PhoneTwo { get; set; }
        public string Adreess { get; set; }
        public DateTime Register { get; set; }
        public string Active { get; set; }
        public IFormFile PhotoPath { get; set; }
    }
  
}
