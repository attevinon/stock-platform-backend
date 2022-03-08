using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Exceptions
{
    /// <summary>
    /// Представляет ошибку, которая возникает при отсутсвии некоторого элемента в базе данных
    /// </summary>
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string exMessage)
            : base(exMessage) { }
    }
}
