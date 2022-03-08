using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Domain;
using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Определяет конфигурацию контент сущности Фотография
    /// </summary>
    internal class TextConfiguration : ProductConfiguration<Text>
    {
        public override void Configure(EntityTypeBuilder<Text> builder)
        {
            base.Configure(builder);

            builder.Property(text => text.Content).IsRequired();
        }
    }
}
