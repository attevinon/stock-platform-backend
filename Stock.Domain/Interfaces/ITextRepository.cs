using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Stock.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория сущности Текст для последующей его реализации,
    /// обеспечивает взаимодействие с Application без привязки к базе данных
    /// </summary>
    public interface ITextRepository : IGenericRepository<Text>
    {
        /// <summary>
        /// Поиск всех контент сущностей Текст
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Text>> GetAllTextsAsync();

        /// <summary>
        /// Поиск контент сущности Текст по её ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Text> GetTextByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создание новой контент сущности Текст
        /// </summary>
        /// <param name="text"></param>
        void CreateText(Text text);
    }
}
