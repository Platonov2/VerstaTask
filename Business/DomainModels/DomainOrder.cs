namespace Business.DomainModels;

/// <summary>
/// Доменная модель заказа
/// </summary>
public class DomainOrder
{
    /// <summary>
    /// Id заказа
    /// </summary>
    public Guid Id { get; set; }

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
