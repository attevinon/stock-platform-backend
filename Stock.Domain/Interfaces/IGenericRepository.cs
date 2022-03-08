using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Stock.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс базового репозитоия для последующей реализации,
    /// обеспечивает взаимодействие с Application без привязки к базе данных.
    /// Наследуется интерфейсами репозиториев для всех сущностей
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity>
    {
        /// <summary>
        /// Поиск сущности с заданными условиями
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Поиск всех сущностей
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> FindAll();

        /// <summary>
        /// Создание новой сущности
        /// </summary>
        /// <param name="entity"></param>
        void Create(TEntity entity);
    }
}
