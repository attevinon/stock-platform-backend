using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория сущности Фотография для последующей его реализации,
    /// обеспечивает взаимодействие с Application без привязки к базе данных
    /// </summary>
    public interface IPhotoRepository : IGenericRepository<Photo>
    {
        /// <summary>
        /// Поиск всех контент сущностей Фотография
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Photo>> GetAllPhotosAsync();

        /// <summary>
        /// Поиск контент сущности Фотография по её ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Photo> GetPhotoByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновление существуйющей контент сущности Фотография
        /// </summary>
        /// <param name="photo"></param>
        void UpdatePhoto(Photo photo);
    }
}
