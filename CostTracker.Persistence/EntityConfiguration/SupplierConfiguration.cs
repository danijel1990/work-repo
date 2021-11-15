using CostTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostTracker.Persistence.EntityConfiguration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public const int MaxNameLength = 50;

        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder
                .HasKey(confLayer => confLayer.Id);

            builder
                .Property(confLayer => confLayer.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(confLayer => confLayer.Address);

            builder
                .Property(confLayer => confLayer.PhoneNumber);
        }
    }
}
