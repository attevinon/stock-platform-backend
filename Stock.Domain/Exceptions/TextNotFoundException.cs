using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Exceptions
{
    /// <summary>
    /// Представляет ошибку, возникающую при отсутсвии в базе данных
    /// сущности Текст с заданным идентификатором
    /// </summary>
    public class TextNotFoundException : NotFoundException
    {
        public TextNotFoundException(Guid photoId)
            : base($"Текст с ID {photoId} не найден") { }
    }
}
