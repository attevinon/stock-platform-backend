using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stock.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Определяет конфигурацию контент сущности Фотография
    /// </summary>
    internal class PhotoConfiguration : ProductConfiguration<Photo>
    {
        public override void Configure(EntityTypeBuilder<Photo> builder)
        {
            base.Configure(builder);

            builder.Property(photo => photo.ContentUrl).IsRequired();
        }
    }
}
