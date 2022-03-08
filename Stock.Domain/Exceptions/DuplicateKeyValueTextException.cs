using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Exceptions
{
    /// <summary>
    /// Представляет ошибку, возникающую при попытке присвоить идентификатор,
    /// который уже существует в базе данных
    /// </summary>
    public sealed class DuplicateKeyValueTextException : BadRequestException
    {
        public DuplicateKeyValueTextException(Guid textId) 
            : base($"Текст с {textId} уже существует.") { }
    }
}
