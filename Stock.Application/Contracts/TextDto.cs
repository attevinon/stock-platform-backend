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
    /// Data Transfer Object, основанный на контент сущности Текст.
    /// Определяет передачу определённой сущности клиенту (GET).
    /// </summary>
    public class TextDto : ProductDto
    {
        public int Length { get; set; }
        public string Content { get; set; }

    }

    /// <summary>
    /// Data Transfer Object, основанный на контент сущности Текст.
    /// Определяет создание определённой сущности клиентом (POST).
    /// </summary>
    public class TextForCreationDto : ProductDtoForCreating
    {
        public int Length { get; }
        public string Content { get; set; }
    }
}
