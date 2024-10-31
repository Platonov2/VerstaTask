using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Contexts;

public class StorageContext : DbContext
{
    public DbSet<OrderRecord> Orders { get; set; }

    public StorageContext(DbContextOptions<StorageContext> options)
            : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlite("Data Source=dataBase.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StorageContext).Assembly);

        var orders = new List<OrderRecord>();
        var order1 = new OrderRecord
        {
            Id = Guid.NewGuid(),
            AddressFrom = "Адрес 1",
            AddressTo = "Адрес 1",
            CityFrom = "Город 1",
            CityTo = "Город 1",
            RecievingDate = new DateOnly(2024, 10, 31),
            Weight = 1
        };
        var order2 = new OrderRecord
        {
            Id = Guid.NewGuid(),
            AddressFrom = "Адрес 2",
            AddressTo = "Адрес 2",
            CityFrom = "Город 2",
            CityTo = "Город 2",
            RecievingDate = new DateOnly(2024, 11, 1),
            Weight = 2
        };
        orders.Add(order1);
        orders.Add(order2);

        modelBuilder.Entity<OrderRecord>().HasData(orders);
    }
}
