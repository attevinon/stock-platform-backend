using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Exceptions
{
    /// <summary>
    /// Представляет ошибку, которая впоследствии возникновения вернёт BadResult (400)
    /// </summary>
    public class BadRequestException : Exception
    {
        protected BadRequestException(string exMessage)
            : base(exMessage) { }
    }
}
