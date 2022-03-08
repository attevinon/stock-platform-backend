using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Interfaces
{
    public interface IGenericProductRepository<TProduct>
    {
        /// <summary>
        /// Поиск всех контент сущностей с включением их владельца
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<TProduct> FindAllWithOwner(Expression<Func<TProduct, IUser>> expression);

        /// <summary>
        /// Поиск сущности с включением её владельца
        /// </summary>
        /// <param name="conditionExpression"></param>
        /// <param name="ownerExpression"></param>
        /// <returns></returns>
        public IQueryable<TProduct> FindByConditionWithOwner(Expression<Func<TProduct, bool>> conditionExpression,
            Expression<Func<TProduct, IUser>> ownerExpression);
    }
}
