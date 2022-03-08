using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock.Domain.Entities;
using Stock.Domain.Interfaces;

namespace Stock.Persistence.Repositories
{
    internal class GenericProductRepository<TProduct> : GenericRepository<TProduct>,
        IGenericProductRepository<TProduct> where TProduct : class
    {
        public GenericProductRepository(RepositoryDbContext dbContext) : base(dbContext) { }

        public IQueryable<TProduct> FindByConditionWithOwner(Expression<Func<TProduct, bool>> conditionExpression,
            Expression<Func<TProduct, IUser>> ownerExpression)
        {
            var entity = DbContext.Set<TProduct>().Where(conditionExpression)
                .Include(ownerExpression).AsNoTracking();
            return entity;
        }
        public IQueryable<TProduct> FindAllWithOwner(Expression<Func<TProduct, IUser>> ownerExpression)
        {
            var entities = DbContext.Set<TProduct>().Include(ownerExpression).AsNoTracking();
            return entities;
        }


    }
}
