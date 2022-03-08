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
    /// с контент сущностью Фотография.
    /// </summary>
    public interface IPhotoService : IGetProductService<PhotoDto>
    {
        /// <summary>
        /// Обеспечивает обновление сущности Фотография с заданным ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="photoDtoUpdated"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateAsync(Guid id, PhotoDtoForUpdating photoDtoUpdated, CancellationToken cancellationToken = default);

    }
}
