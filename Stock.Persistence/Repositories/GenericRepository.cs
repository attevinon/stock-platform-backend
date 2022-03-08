using Microsoft.EntityFrameworkCore;
using Stock.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Stock.Persistence.Repositories
{
    /// <summary>
    /// Базовый репозиторий, определяющий
    /// методы, используемые всеми другими репозиториями.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public RepositoryDbContext DbContext { get; set; }

        //определяет контенст базы данных, общий для всех других репозиториев
        public GenericRepository(RepositoryDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            var entity = DbContext.Set<TEntity>().Where(expression).AsNoTracking();
            return entity;
        }

        public IQueryable<TEntity> FindAll()
        {
            var entities = DbContext.Set<TEntity>().AsNoTracking();
            return entities;
        }

        public void Create(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }
    }
}
