using Microsoft.EntityFrameworkCore;
using Stock.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stock.Persistence
{
    /// <summary>
    /// Определяет контекст базы данных общий для всех репозиториев
    /// </summary>
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options) 
            : base(options)
        {
            //инициализация базы данных (НЕОБХОДИМО УБИРАТЬ ВО ВРЕМЯ ОБНОВЛЕНИЯ БАЗЫ ДАННЫХ)
            this.Initialize();
        }

        public DbSet<Text> Texts { get; set; }
        public DbSet<Photo> Photos {get; set;}
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //установка конфигураций
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);

        }
    }
}
