using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Exceptions
{
    /// <summary>
    /// Представляет ошибку, возникающую при отсутсвии в базе данных
    /// сущности Фотография с заданным идентификатором
    /// </summary>
    public sealed class PhotoNotFoundException : NotFoundException
    {
        public PhotoNotFoundException(Guid photoId) 
            : base($"Фотография с ID {photoId} не найдена") { }
    }
}
