using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Service.Interfaces
{
    /// <summary>
    /// Обеспечивает взаимодействие контроллеров со всеми другими сервисами
    /// </summary>
    public interface IServiceManager
    {
        ITextService TextService { get; }
        IPhotoService PhotoService { get; }
        IProductsService ProductService { get; }

    }
}
