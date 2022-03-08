using Microsoft.EntityFrameworkCore;
using Stock.Persistence;
using Stock.Domain.Models;
using System;
using Xunit;

namespace Stock.Tests
{
    public class StockContextFactory
    {
        public static Guid PhotoIdForUpdate = Guid.NewGuid();
        public static Guid PhotoIdForGet = Guid.NewGuid();

        public static Guid TextAId = Guid.NewGuid();
        public static Guid TextBId = Guid.NewGuid();

        public static RepositoryDbContext Create()
        {
            var options = new DbContextOptionsBuilder<RepositoryDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var context = new RepositoryDbContext(options);
            context.Database.EnsureCreated();
            context.Photos.AddRange(
                new Photo
                {
                    Name = "PhotoDandelion",
                    Id = Guid.Parse("{36B2DE92-B22D-4654-AAF4-32F56E7343EA}"),
                    ContentUrl = "https://tnn-garden.ru/wp-content/uploads/2014/07/Dandelions.jpg",
                    Height = 362,
                    Width = 640,
                    Author = new Author { Username = "user2222" },
                    Price = 3,
                    Sales = 5,
                    CreationDate = DateTime.Today
                },
                new Photo
                {
                    Name = "PhotoHacker",
                    Id = Guid.Parse("{9D3E5D74-24FE-43D9-B1E1-11951F5001C0}"),
                    ContentUrl = "https://nedelya40.ru/wp-content/uploads/2021/08/1629469273420.jpg",
                    Height = 536,
                    Width = 900,
                    Author = new Author { Username = "user2222" },
                    Price = 99,
                    Sales = 470,
                    CreationDate = DateTime.Today
                },
                new Photo
                {
                    Name = "PhotoQwerty",
                    Id = PhotoIdForUpdate,
                    ContentUrl = "https://torbafood.ua/upload/iblock/0cd/0cda55b3a2d3c576358303a91b9da8e5.jpg",
                    Height = 700,
                    Width = 700,
                    Author = new Author { Username = "NewUsername" },
                    Price = 10,
                    Sales = 0,
                    CreationDate = DateTime.Today
                },
                new Photo
                {
                    Name = "PhotoCar",
                    Id = PhotoIdForGet,
                    ContentUrl = "https://images.drive.ru/i/0/5dd78d50ec05c4497b000003.jpg",
                    Height = 520,
                    Width = 920,
                    Author = new Author { Username = "MaskUserName" },
                    Price = 1000000,
                    Sales = 7,
                    CreationDate = DateTime.Today
                }
            );

            context.Authors.AddRange(
                new Author
                {
                    Name = "Ilon Mask",
                    Username = "MaskUserName",
                    RegistrationDate = DateTime.Today,
                    Age = 50
                },
                new Author
                {
                    Name = "Name111",
                    Username = "user1111",
                    RegistrationDate = DateTime.Today,
                    Age = 21
                },
                new Author
                {
                    Name = "Name222",
                    Username = "user2222",
                    RegistrationDate = DateTime.Today,
                    Age = 22
                }
            );

            context.Texts.AddRange(
                new Text
                {
                    Name = "Text 1",
                    Content = "Text text text text text text text text ttttteeeeexxxxxttttt 1111111",
                    Price = 1,
                    Sales = 0,
                    Author = new Author { Username = "user1111" },
                    CreationDate = DateTime.Today
                }
            );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(RepositoryDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}