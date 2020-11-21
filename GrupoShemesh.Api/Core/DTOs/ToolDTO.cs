using Administration.Enum;
using GrupoShemesh.Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace GrupoShemesh.Api.Core.DTOs
{
    public class ToolDTO
    {
        public int Id { get; set; }

        public string NameTool { get; set; }

        public string Brand { get; set; }

        public string Serie { get; set; }

        public string Model { get; set; }

        public string PhotoPath { get; set; }

        public EState? State { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string TechnicalSpecifications { get; set; }

        public string Observations { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int CustomerId { get; set; }
    }
    public class ToolAddOrEditDTO
    {
        public string NameTool { get; set; }

        public string Brand { get; set; }

        public string Serie { get; set; }

        public string Model { get; set; }

        public IFormFile PhotoPath { get; set; }

        public EState? State { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string TechnicalSpecifications { get; set; }

        public string Observations { get; set; }

        public int CategoryId { get; set; }
        public int CustomerId { get; set; }
        public string User { get; set; }

    }
}
