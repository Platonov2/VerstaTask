using Microsoft.EntityFrameworkCore;
using Storage.Contexts;
using Storage.Entities;

namespace Storage.Repositories.Orders;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly StorageContext storageContext;

    public OrderRepository(StorageContext storageContext)
    {
        this.storageContext = storageContext;
    }

    public Task<List<OrderRecord>> GetAllOrdersAsync(CancellationToken token)
    {
        return storageContext.Orders.ToListAsync(token);
    }

    public Task<OrderRecord?> GetOrderAsync(Guid id, CancellationToken token)
    {
        return storageContext.Orders.FirstOrDefaultAsync(o => o.Id == id, token);
    }

    public async Task<Guid> CreateAsync(OrderRecord order, CancellationToken token)
    {
        await storageContext.Orders.AddAsync(order, token);
        await storageContext.SaveChangesAsync(token);

        return order.Id;
    }
}
