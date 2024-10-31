using System.ComponentModel.DataAnnotations;

namespace Storage.Entities;

/// <summary>
/// Сущность заказа
/// </summary>
public class OrderRecord
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
    [DataType(DataType.Date)]
    public DateOnly RecievingDate { get; set; }
}
