using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Interfaces
{
    /// <summary>
    /// Обеспечивает взаимодействие Application со всеми другими репозиториями
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// Представляет репозиторий контент сущности Текст
        /// </summary>
        ITextRepository Text {get; }

        /// <summary>
        /// Представляет репозиторий контент сущности Фотография 
        /// </summary>
        IPhotoRepository Photo { get; }

        /// <summary>
        /// Представляет репозиторий сущности Автор
        /// </summary>
        IAuthorRepository Author { get; }

        /// <summary>
        /// Представляет обработчик взаимодествия со всеми изменениями,
        /// внесёнными в контекст базы данных
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }
}
