using Business.DomainModels;

namespace Business.Services.Order;

/// <summary>
/// Сервис заказов
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Получение всех заказов
    /// </summary>
    public Task<ICollection<DomainOrder>> GetAllAsync(CancellationToken token = default);

    /// <summary>
    /// Получение заказа по Id
    /// </summary>
    public Task<DomainOrder?> GetAsync(Guid id, CancellationToken token = default);

    /// <summary>
    /// Создание заказа
    /// </summary>
    public Task<Guid> CreateAsync(DomainOrder order, CancellationToken token = default);
}
