using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Entities;

namespace Storage.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<OrderRecord>
{
    public void Configure(EntityTypeBuilder<OrderRecord> builder)
    {
        builder.HasIndex(o => o.Id).IsUnique();
        builder.Property(b => b.AddressFrom).IsRequired();
        builder.Property(b => b.AddressTo).IsRequired();
        builder.Property(b => b.CityFrom).IsRequired();
        builder.Property(b => b.CityTo).IsRequired();
        builder.Property(b => b.RecievingDate).IsRequired();
        builder.Property(b => b.Weight).IsRequired();

        builder.ToTable("Orders");
    }
}
