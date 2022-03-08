using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stock.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Определяет конфигурацию сущности Автор
    /// </summary>
    internal class AuthorConfiguration : UserConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);

            //установление отношения один-ко-многим между сущностью Автор и контент сущностями (продуктами)
            builder.HasMany<ConcreteProduct>().WithOne(product => product.ProductAuthor).IsRequired();
        }
    }
}
