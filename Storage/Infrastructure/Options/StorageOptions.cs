namespace Storage.Infrastructure.Options;

public sealed class StorageOptions
{
    public const string SectionName = "Storage";

    public string? ConnectionString { get; init; }

    public string RequiredConnectionString => ConnectionString ??
        throw new InvalidOperationException($"Не задано значение {nameof(ConnectionString)}");
}
