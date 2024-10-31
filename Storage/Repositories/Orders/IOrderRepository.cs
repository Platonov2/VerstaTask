using Storage.Entities;

namespace Storage.Repositories.Orders;

/// <summary>
/// Репозиторий заказов
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Получение всех заказов из БД
    /// </summary>
    public Task<List<OrderRecord>> GetAllOrdersAsync(CancellationToken token);

    /// <summary>
    /// Получение заказа по Id
    /// </summary>
    public Task<OrderRecord?> GetOrderAsync(Guid id, CancellationToken token);

    /// <summary>
    /// Сохранение заказа в БД  
    /// </summary>
    public Task<Guid> CreateAsync(OrderRecord record, CancellationToken token);
}
