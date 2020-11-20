using Microsoft.AspNetCore.Http;
using System;

namespace GrupoShemesh.Core.DTOs
{
    public class CustomerPostDto
    {
        public int Id { get; set; }
        public string NameCustomer { get; set; }
        public string RFC { get; set; }
        public string PhoneOne { get; set; }
        public string PhoneTwo { get; set; }
        public string Adreess { get; set; }
        public DateTime Register { get; set; }
        public bool Active { get; set; }
        public string PhotoPath { get; set; }
        public IFormFile Img { get; set; }
    }
}
