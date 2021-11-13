using CostTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CostTracker.Persistence.EntityConfiguration
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public const int MaxNameLength = 50;

        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder
                .HasKey(confLayer => confLayer.Id);

            builder
                .Property(confLayer => confLayer.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(confLayer => confLayer.Name)
                .IsRequired();              
        }
    }
}
