using AutoMapper;
using Business.DomainModels;
using VerstaTask.Models.Orders;

namespace VerstaTask.Automapper;

public class ViewMapperProfile : Profile
{
    public ViewMapperProfile() 
    {
        CreateMap<Order, DomainOrder>();

        CreateMap<DomainOrder, Order>();

        CreateMap<CreateOrderRequest, DomainOrder>();
    }
}
