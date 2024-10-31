using AutoMapper;
using Business.DomainModels;
using Storage.Entities;

namespace Business.Infrastructure.Automapper;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<DomainOrder, OrderRecord>();

        CreateMap<OrderRecord, DomainOrder>();
    }
}
