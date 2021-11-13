using CostTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CostTracker.Persistence.EntityConfiguration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public const int MaxDescriptionLength = 500;

        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder
               .HasKey(confLayer => confLayer.Id);

            builder
                .Property(confLayer => confLayer.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);

            builder
                .Property(confLayer => confLayer.InvoiceDate);

            builder
                .HasOne(confLayer => confLayer.Supplier)
                .WithMany(confLayer => confLayer.Invoices)
                .HasForeignKey(confLayer => confLayer.SupplierId);

            builder
                .HasMany(confLayer => confLayer.InvoiceMaterials)
                .WithOne(confLayer => confLayer.Invoice)
                .HasForeignKey(confLayer => confLayer.InvoiceId);
        }
    }
}
