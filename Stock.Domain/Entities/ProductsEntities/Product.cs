

namespace Stock.Domain.Entities
{
    /// <summary>
    /// Абстрактный класс, представляющий продукт (контент сущность)
    /// </summary>
    public abstract class Product : IProduct
    {
        //идентификатор продукта
        public Guid Id { get; set; }

        //название продукта
        public string Name { get; set; }

        //дата создания продукта
        public DateTime CreationDate { get; set; }

        //цена продукта
        public decimal Price { get; set; }

        //количество проданных продуктов
        public int Sales { get; set; }

        //сущность Автор, которой принадлежит продукт
        public Author ProductAuthor { get; set; }
    }
}
