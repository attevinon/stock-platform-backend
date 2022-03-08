using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория сущности Автор для последующей его реализации,
    /// обеспечивает взаимодействие с Application без привязки к базе данных
    /// </summary>
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        /// <summary>
        /// Поиск сущности Автор по его никнейму
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<Author> GetAuthorByUsername(string username);

        /// <summary>
        /// Создание новой сущности Автор
        /// </summary>
        /// <param name="author"></param>
        void CreateAuthor(Author author);
    }
}
