

namespace Stock.Domain.Entities
{
    /// <summary>
    /// Контент сущность Текст
    /// </summary>
    public class Text : Product
    {
        //размер текста
        public int Length { get; set; }

        //содержание текста (контент)
        public string Content { get; set; }
    }
}
