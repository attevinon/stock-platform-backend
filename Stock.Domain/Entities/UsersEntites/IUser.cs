

namespace Stock.Domain.Entities
{
    /// <summary>
    /// Интерфейс для определения пользователя
    /// </summary>
    public interface IUser
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
