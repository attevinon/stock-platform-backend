

namespace Stock.Domain.Entities
{
    /// <summary>
    /// Сущность Автор
    /// </summary>
    public class Author : IUser
    {
        //имя автора
        public string? Name { get; set; }

        //никнейм автора
        public string Username { get; set; }

        //возраст автора
        public int Age { get; set; }

        //дата регистрации автора
        public DateTime RegistrationDate { get; set; }

        //коллекция продуктов, которыми владеет автор
        //добавлено чтобы установить отношение один-ко-многим 
        //(navigation property)
        public ICollection<ConcreteProduct>? OwnedProducts { get; set; }

    }
}
