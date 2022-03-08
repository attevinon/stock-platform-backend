using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Persistence.EntityTypeConfigurations
{
    internal class UserConfiguration<TUser> : IEntityTypeConfiguration<TUser> where TUser : class, IUser
    {
        public virtual void Configure(EntityTypeBuilder<TUser> builder)
        {
            builder.HasKey(user => user.Username);
            builder.Property(user => user.Username).IsRequired();
            builder.Property(user => user.Username).IsUnicode();
            builder.Property(user => user.Username).HasMaxLength(20);

            builder.Property(user => user.Name).HasMaxLength(50);
        }
    }
}
