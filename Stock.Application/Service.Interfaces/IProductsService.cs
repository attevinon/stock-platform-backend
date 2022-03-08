using Stock.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Service.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса, определяющий методы для взаимодейтсвия клиента
    /// со всеми контент сущностями (продуктами) одновременно
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Обеспечивает выведение всех контент сущностей (продуктов) в один список
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);


    }
}
