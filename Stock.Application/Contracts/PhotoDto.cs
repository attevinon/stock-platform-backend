using Stock.Domain.Interfaces;
using Stock.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Contracts
{
    /// <summary>
    /// Data Transfer Object, основанный на контент сущности Фотография.
    /// Определяет передачу определённой сущности клиенту (GET).
    /// </summary>
    public class PhotoDto : ProductDto
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string ContentUrl { get; set; }
    }

    /// <summary>
    /// Data Transfer Object, основанный на контент сущности Фотография.
    /// Определяет обновление определённой сущности клиентом (PUT).
    /// </summary>
    public class PhotoDtoForUpdating : ProductDtoForUpdating
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string ContentUrl { get; set; }
    }
}
