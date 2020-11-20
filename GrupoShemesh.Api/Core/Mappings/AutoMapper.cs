using AutoMapper;
using GrupoShemesh.Api.Core;
using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Entities;

namespace GrupoShemesh.Core
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Bank, BankDto>();
            CreateMap<BankDto, Bank>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();


            CreateMap<Customer, CustomerPostDto>();
            CreateMap<CustomerPostDto, Customer>();
            //CreateMap<Customer, CustomerCB>();
            //CreateMap<CustomerCB, Customer>();


            //CreateMap<Origen, Destino>();

        }
    }
}
