using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Models;
using System.Linq;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Mapping
            CreateMap<user, UserResponse>()
                .ForMember(dest => dest.roles, opt => opt.MapFrom(src => src.roles.Select(r => r.name)));
            CreateMap<UserCreateRequest, user>();

            // Customer Mapping
            CreateMap<customer, CustomerResponse>();
            CreateMap<CustomerRequest, customer>();

            // Incubator Mapping
            CreateMap<incubator, IncubatorResponse>()
                .ForMember(dest => dest.model_name, opt => opt.MapFrom(src => src.model.name))
                .ForMember(dest => dest.customer_name, opt => opt.MapFrom(src => src.customer != null ? src.customer.name : "N/A"));
            CreateMap<IncubatorRequest, incubator>();

            // Sales Order Mapping
            CreateMap<sales_order, SalesOrderResponse>()
                .ForMember(dest => dest.customer_name, opt => opt.MapFrom(src => src.customer.name))
                .ForMember(dest => dest.order_date, opt => opt.MapFrom(src => src.order_date.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.items, opt => opt.MapFrom(src => src.sales_order_items));
            
            CreateMap<sales_order_item, OrderItemResponse>()
                .ForMember(dest => dest.serial_number, opt => opt.MapFrom(src => src.incubator.serial_number))
                .ForMember(dest => dest.model_name, opt => opt.MapFrom(src => src.incubator.model.name));
            
            CreateMap<SalesOrderRequest, sales_order>()
                .ForMember(dest => dest.order_date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.order_date)));

            // Maintenance Mapping
            CreateMap<maintenance_ticket, MaintenanceTicketResponse>()
                .ForMember(dest => dest.incubator_serial, opt => opt.MapFrom(src => src.incubator.serial_number))
                .ForMember(dest => dest.technician_name, opt => opt.MapFrom(src => src.technician != null ? src.technician.full_name : "Unassigned"))
                .ForMember(dest => dest.logs, opt => opt.MapFrom(src => src.maintenance_logs));
            
            CreateMap<maintenance_log, MaintenanceLogResponse>();
            CreateMap<MaintenanceTicketRequest, maintenance_ticket>();
            CreateMap<MaintenanceLogRequest, maintenance_log>();

            // Incubator Model Mapping
            CreateMap<incubator_model, IncubatorModelResponse>();
            CreateMap<IncubatorModelRequest, incubator_model>();

            // Warranty Mapping
            CreateMap<warranty, WarrantyResponse>()
                .ForMember(dest => dest.incubator_serial, opt => opt.MapFrom(src => src.incubator.serial_number))
                .ForMember(dest => dest.qr_code, opt => opt.MapFrom(src => src.incubator.qr_code))
                .ForMember(dest => dest.customer_name, opt => opt.MapFrom(src => src.incubator.customer != null ? src.incubator.customer.name : "N/A"))
                .ForMember(dest => dest.start_date, opt => opt.MapFrom(src => src.start_date.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.end_date, opt => opt.MapFrom(src => src.end_date.ToDateTime(TimeOnly.MinValue)));

            CreateMap<WarrantyRequest, warranty>()
                .ForMember(dest => dest.start_date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.start_date)))
                .ForMember(dest => dest.end_date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.end_date)));
        }
    }
}
