using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Domain.Entities;

namespace Stock.Persistence.EntityTypeConfigurations
{
    internal class ProductConfiguration<TEntity> 
        : IEntityTypeConfiguration<TEntity> where TEntity : class, IProduct
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(product => product.Id);
            builder.HasIndex(product => product.Id).IsUnique();

            builder.Property(product => product.Name).IsRequired();
            builder.Property(product => product.Name).HasMaxLength(50);

            builder.Property(product => product.Price).IsRequired();

            builder.HasOne(product => product.ProductAuthor).WithMany();
        }
    }
}
