using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Service.Interfaces
{
    public interface IGetProductService<TEntityDto>
    {
        /// <summary>
        /// Обеспечивает получение всех контент сущностей определённого вида в один список
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntityDto>> GetAllAsync(CancellationToken cancellationToken = default);


        /// <summary>
        /// Обеспечивает поиск контент сущности с заданным ID
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntityDto> GetById(Guid productId, CancellationToken cancellationToken = default);
    }
}
