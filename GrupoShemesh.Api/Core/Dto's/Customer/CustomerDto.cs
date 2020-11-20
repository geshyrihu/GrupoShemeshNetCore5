using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Core
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string NameCustomer { get; set; }
        public string RFC { get; set; }
        public string PhoneOne { get; set; }
        public string PhoneTwo { get; set; }
        public string Adreess { get; set; }
        public DateTime Register { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
        public string PhotoPath { get; set; }
    }
}
