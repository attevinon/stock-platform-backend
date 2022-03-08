
namespace Stock.Domain.Entities
{
    /// <summary>
    /// Контент сущность Фотография
    /// </summary>
    public class Photo : Product
    {
        //размеры
        public int Height { get; set; }
        public int Width { get; set; }
        //ссылка на контент
        public string ContentUrl { get; set; }
    }
}
