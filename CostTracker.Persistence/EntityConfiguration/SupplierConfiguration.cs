using CostTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
