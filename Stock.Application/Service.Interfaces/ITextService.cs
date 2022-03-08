using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Application.Contracts;

namespace Stock.Application.Service.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса, определяющий методы для взаимодейтсвия клиента
    /// с контент сущностью Текст.
    /// </summary>
    public interface ITextService : IGetProductService<TextDto>
    {
        /// <summary>
        /// Обеспечивает создание (добавление) новой контент сущности Текст
        /// </summary>
        /// <param name="textDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TextDto> CreateText(TextForCreationDto textDto, CancellationToken cancellationToken = default);
    }
}
