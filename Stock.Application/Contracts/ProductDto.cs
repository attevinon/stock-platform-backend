using Mapster;
using Stock.Domain.Entities;

namespace Stock.Application.Contracts
{
    //[GenerateMapper]
    /// <summary>
    /// Data Transfer Object, основанный на абстрактной сущности Продукт.
    /// Определяет передачу определённой сущности клиенту (GET).
    /// </summary>
    public abstract class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }
        public int Sales { get; }
        public string AuthorName { get; set; }
        public string AuthorUsername { get; set; }
    }

    /// <summary>
    /// Data Transfer Object, основанный на абстрактной сущности Продукт.
    /// Определяет обновление определённой сущности клиентом (PUT).
    /// В данном этапе разработки программы не имеет специфичных свойств,
    /// но будет полезен при расширении программы.
    /// </summary>
    public abstract class ProductDtoForUpdating
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }
        public int Sales { get; }
        public string AuthorName { get; set; }
        public string AuthorUsername { get; set; }
    }

    /// <summary>
    /// Data Transfer Object, основанный на абстрактной сущности Продукт.
    /// Определяет создание определённой сущности клиентом (PUT).
    /// В данном этапе разработки программы не имеет специфичных свойств,
    /// но будет полезен при расширении программы.
    /// </summary>
    public abstract class ProductDtoForCreating
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }
        public int Sales { get; }
        public string AuthorName { get; set; }
        public string AuthorUsername { get; set; }
    }
}
