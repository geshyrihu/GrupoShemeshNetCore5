using AutoMapper;
using GrupoShemesh.Api.Core;
using GrupoShemesh.Api.Core.DTOs;
using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Entities;

namespace GrupoShemesh.Core
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Bank, BankDTO>().ReverseMap();
            CreateMap<BankAddOrEditDTO, Bank>();

            CreateMap<Meeting, MeetingDTO>().ReverseMap();


            CreateMap<ContactEmployee, ContactEmployeeDTO>().ReverseMap();
            CreateMap<ContactEmployeeAddOrEditDTO, ContactEmployee>();    
            
            CreateMap<MaintenanceOrder, MaintenanceOrderDTO>()
                .ForMember(x => x.Activity, options => options.MapFrom(x => x.MaintenanceCalendar.Activity))
                .ForMember(x => x.NameMachinery, options => options.MapFrom(x => x.MaintenanceCalendar.Machinery.NameMachinery));

            CreateMap<MaintenanceOrderUpdateDTO, MaintenanceOrder>()
                    .ForSourceMember(x => x.Activity, options => options.DoNotValidate())
                    .ForSourceMember(x => x.NameMachinery, options => options.DoNotValidate());



            CreateMap<MeetingDetails, MeetingDetailsReportDTO>().ReverseMap();
            CreateMap<MeetingDetails, MettingetailsDto>().ReverseMap();


            CreateMap<Customer, CustomerGetDto>().ReverseMap();
            CreateMap<CustomerAddOrEditDto, Customer>()
                .ForMember(x => x.PhotoPath, options => options.Ignore());
            
            // ...Reportes de Operación 
            CreateMap<WeeklyReport, WeeklyReportDTO>().ReverseMap();
            CreateMap<WeeklyReport, WeeklyReportPDFDTO>().ReverseMap();
            CreateMap<WeeklyReportAddOrEditDTO, WeeklyReport>()
                .ForMember(x => x.PhotoPathAfter, options => options.Ignore())
                .ForMember(x => x.PhotoPathBefore, options => options.Ignore())
                .ForMember(x => x.User, options => options.Ignore());


            // ...Inventario de Maquinarias
            CreateMap<Machinery, MachineryDto>().ReverseMap();
            CreateMap<MachineryAddOrEditDto, Machinery>()
                .ForMember(x => x.User, options => options.Ignore())
                .ForMember(x => x.PhotoPath, options => options.Ignore());
            
            // ...Inventario de Herramientas
            CreateMap<Tool, ToolDTO>().ReverseMap();
            CreateMap<ToolAddOrEditDTO, Tool>()
                .ForMember(x => x.User, options => options.Ignore())
                .ForMember(x => x.PhotoPath, options => options.Ignore());

            // ...Empleados
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeAddOrEditDTO, Employee>()
                .ForMember(x => x.PhotoPath, options => options.Ignore());

            // ...Proveedores
            CreateMap<Provider, ProviderDTO>().ReverseMap();
            CreateMap<ProviderAddOrEditDTO, Provider>()
                .ForMember(x => x.User, options => options.Ignore())
                .ForMember(x => x.PathPhoto, options => options.Ignore());
            
            // ...Forma de pago
            CreateMap<PaymentMethod, PaymentMethodDTO>().ReverseMap();
            CreateMap<PaymentMethodAddOrEitDTO, PaymentMethod>();
        }
    }
}
