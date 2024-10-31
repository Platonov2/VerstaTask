
using AutoMapper;
using Business.DomainModels;
using Storage.Entities;
using Storage.Repositories.Orders;

namespace Business.Services.Order;

internal sealed class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly IMapper mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        this.orderRepository = orderRepository;
        this.mapper = mapper;
    }

    public async Task<ICollection<DomainOrder>> GetAllAsync(CancellationToken token)
    {
        var dbOrders = await orderRepository.GetAllOrdersAsync(token);

        return mapper.Map<ICollection<DomainOrder>>(dbOrders);
    }

    public async Task<DomainOrder?> GetAsync(Guid id, CancellationToken token)
    {
        var dbOrder = await orderRepository.GetOrderAsync(id, token);

        return mapper.Map<DomainOrder>(dbOrder);
    }

    public async Task<Guid> CreateAsync(DomainOrder domainOrder, CancellationToken token)
    {
        var storedOrder = await orderRepository.GetOrderAsync(domainOrder.Id, token);
        if (storedOrder is null)
        {
            var newOrder = mapper.Map<OrderRecord>(domainOrder);
            await orderRepository.CreateAsync(newOrder, token);
        }

        return domainOrder.Id;
    }
}
