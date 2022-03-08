using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для обработки сущностей, измененными/созданными пользователем
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Сохранение всех созданных/измененных сущностей в базу данных
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
