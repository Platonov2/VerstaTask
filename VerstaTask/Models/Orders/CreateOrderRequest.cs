namespace VerstaTask.Models.Orders;

/// <summary>
/// Модель запроса на создание заказа
/// </summary>
public sealed class CreateOrderRequest
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id {  get; set; }

    /// <summary>
    /// Город отправителя
    /// </summary>
    public string? CityFrom { get; set; }

    /// <summary>
    /// Город получателя
    /// </summary>
    public string? CityTo { get; set; }

    /// <summary>
    /// Адрес отправителя
    /// </summary>
    public string? AddressFrom { get; set; }

    /// <summary>
    /// Адрес получателя
    /// </summary>
    public string? AddressTo { get; set; }

    /// <summary>
    /// Вес груза
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// Дата забора груза
    /// </summary>
    public DateOnly RecievingDate { get; set; }
}
