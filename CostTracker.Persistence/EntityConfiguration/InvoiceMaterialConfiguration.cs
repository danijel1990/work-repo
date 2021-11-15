using CostTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostTracker.Persistence.EntityConfiguration
{
    public class InvoiceMaterialConfiguration : IEntityTypeConfiguration<InvoiceMaterial>
    {
        public void Configure(EntityTypeBuilder<InvoiceMaterial> builder)
        {
            builder
               .HasKey(confLayer => new { confLayer.InvoiceId, confLayer.MaterialId } );

            builder
                .HasOne(confLayer => confLayer.Invoice)
                .WithMany(confLayer => confLayer.InvoiceMaterials);

            builder
                .HasOne(confLayer => confLayer.Material);

            builder
                .Property(confLayer => confLayer.Quantity)
                .IsRequired();
        }
    }
}
