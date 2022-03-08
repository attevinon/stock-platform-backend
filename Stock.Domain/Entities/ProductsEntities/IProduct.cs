

namespace Stock.Domain.Entities
{
    /// <summary>
    /// Интерфейс, представляющий любой продукт на сайте (контент сущность)
    /// </summary>
    public interface IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }
        public int Sales { get; set; }
        public Author ProductAuthor { get; set; }
    }
}
