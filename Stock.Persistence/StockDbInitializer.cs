using Stock.Domain.Entities;

namespace Stock.Persistence
{
    internal static class StockDbInitializer
    {
        /// <summary>
        /// Инициализация базы данных определёнными занчениями
        /// </summary>
        /// <param name="dbContext"></param>
        public static void Initialize(this RepositoryDbContext dbContext)
        {
            //если базы данных не существует, то она создаётся
            dbContext.Database.EnsureCreated();

            //если в базе данных уже есть сущности Автор, то она не создаётся
            if (dbContext.Authors.Any())
                return;

            var authors = new Author[]
            {
                
                new Author
                {
                    Name = "Ilon Mask",
                    Username = "MaskUserName",
                    RegistrationDate = DateTime.Today,
                    Age = 50
                },
                new Author
                {
                    Name = "Name1",
                    Username = "user1",
                    RegistrationDate = DateTime.Today,
                    Age = 21
                },
                new Author
                {
                    Name = "Name2",
                    Username = "user2",
                    RegistrationDate = DateTime.Today,
                    Age = 22
                }
            };

            //сущности добавляются в контекст базы данных
            dbContext.Authors.AddRange(authors);

            var photos = new Photo[]
            {
                new Photo
                {
                    Id = Guid.Parse("{36B2DE92-B22D-4654-AAF4-32F56E7343EA}"),
                    Name = "PhotoDandelion",
                    ContentUrl = "https://tnn-garden.ru/wp-content/uploads/2014/07/Dandelions.jpg",
                    ProductAuthor = dbContext.Authors.Find("user1") ?? CreateAuthor(),
                    Height = 362,
                    Width = 640,
                    Price = 3,
                    Sales = 5,
                    CreationDate = DateTime.Today
                },
                new Photo
                {
                    Id = Guid.Parse("{9D3E5D74-24FE-43D9-B1E1-11951F5001C0}"),
                    Name = "PhotoHackerman",
                    ContentUrl = "https://nedelya40.ru/wp-content/uploads/2021/08/1629469273420.jpg",
                    ProductAuthor = dbContext.Authors.Find("user2") ?? CreateAuthor(),
                    Height = 536,
                    Width = 900,
                    Price = 99,
                    Sales = 470,
                    CreationDate = DateTime.Today
                },
                new Photo
                {
                    Id = Guid.Parse("{8137F777-9BF9-4155-8613-74BA52BBA6F7}"),
                    Name = "PhotoTea",
                    ContentUrl = "https://torbafood.ua/upload/iblock/0cd/0cda55b3a2d3c576358303a91b9da8e5.jpg",
                    ProductAuthor = dbContext.Authors.Find("user121212") ?? CreateAuthor(),
                    Height = 700,
                    Width = 700,
                    Price = 10,
                    Sales = 0,
                    CreationDate = DateTime.Today
                },
                new Photo
                {
                    Id =  Guid.Parse("{E46DA190-3C28-4AF5-AC18-522368140B50}"),
                    Name = "PhotoCar",
                    ContentUrl = "https://images.drive.ru/i/0/5dd78d50ec05c4497b000003.jpg",
                    Height = 520,
                    Width = 920,
                    ProductAuthor = dbContext.Authors.Find("MaskUserName")  ?? CreateAuthor(),
                    Price = 1000000,
                    Sales = 7,
                    CreationDate = DateTime.Today
                }
            };

            //сущности добавляются в контекст базы данных
            dbContext.Photos.AddRange(photos);

            var texts = new Text[]
            {
                new Text
                {
                    Id = Guid.Parse("{76942A37-A392-415E-9382-AF1EA41062DA}"),
                    Name = "Хлам",
                    Content = "Когда рядом никого нет, хлам размножается." +
                    " Ну, скажем, если ты лег спать, не убрав скопившийся в квартире хлам," +
                    " наутро его будет вдвое больше. Его всегда становится все больше и больше.",
                    ProductAuthor = dbContext.Authors.Find("user1") ?? CreateAuthor(),
                    Price = 2,
                    CreationDate = DateTime.Today
                }
            };

            //сущности Текст добавляются в контекст базы данных,
            //присваивается значение размера текста
            foreach (var text in texts)
            {
                text.Length = text.Content.Length;
                dbContext.Texts.Add(text);
            }

            //сохранение
            dbContext.SaveChanges();
        }

        private static Random random = new Random(100);

        /// <summary>
        /// создание автора, если соответсвующему полю контент сущностей
        /// не было присвоено значение
        /// </summary>
        /// <returns></returns>
        private static Author CreateAuthor()
            => new Author { Username = "NewAuthor" + random.Next() };

        //в реальном проекте не было бы актуально,
        //в случае такой проверочной инициализации базы данных удобно для избегания ошибок
    }
}
