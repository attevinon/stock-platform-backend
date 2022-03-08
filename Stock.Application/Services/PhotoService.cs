using Stock.Application.Contracts;
using Stock.Application.Service.Interfaces;
using Stock.Domain.Interfaces;
using Stock.Domain.Entities;
using Stock.Domain.Exceptions;
using System.Collections.Generic;
using Mapster;

namespace Stock.Application.Services
{
    /// <summary>
    /// Представляет логику взаимодействия клиента с контент сущностью Фотография
    /// </summary>
    internal class PhotoService : IPhotoService
    {
        //обеспечивает взаимодейтсвие Application с репозиториями (и => базой данных)
        private readonly IRepositoryManager repositoryManager;

        /// <summary>
        /// Конструктор устанавливает репозиторий для взаимодействия с базой данных
        /// </summary>
        /// <param name="repositoryManager"></param>
        public PhotoService(IRepositoryManager repositoryManager) 
            => this.repositoryManager = repositoryManager;

        public async Task<IEnumerable<PhotoDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            //поиск всех контент сущностей Фотография в базе данных
            var photos = await repositoryManager.Photo.GetAllPhotosAsync();

            //конвертация контент сущностей Фотография в DTO
            var photosDto = photos.Adapt<IEnumerable<PhotoDto>>();

            return photosDto;
        }

        public async Task<PhotoDto> GetById(Guid photoId, CancellationToken cancellationToken = default)
        {
            //поиск фотографии с заданным ID
            var photo = await repositoryManager.Photo.GetPhotoByIdAsync(photoId, cancellationToken);

            //в случае отсутсвии такой фотографии возникает исключение
            if (photo == null)
                throw new PhotoNotFoundException(photoId);

            //конвертация контент сущности Фотография в DTO
            var photoDto = photo.Adapt<PhotoDto>();

            return photoDto;
        }

        public async Task UpdateAsync(Guid id, PhotoDtoForUpdating photoDtoUpdated, CancellationToken cancellationToken = default)
        {
            //поиск фотографии с заданным ID
            var photo = await repositoryManager.Photo.GetPhotoByIdAsync(id, cancellationToken);

            //в случае отсутсвии такой фотографии возникает исключение
            if (photo == null)
                throw new PhotoNotFoundException(id);

            //поиск в базе данных авторов с никнеймом, указанным пользователем
            Author author = await repositoryManager.Author.GetAuthorByUsername(photoDtoUpdated.AuthorUsername);

            //если такого автора нет, то он создаётся
            if (author == null)
            {
                author = new Author
                {
                    Username = photoDtoUpdated.AuthorUsername,
                    Name = photoDtoUpdated.AuthorName ?? "Unknown",
                    RegistrationDate = DateTime.Now
                };

                repositoryManager.Author.CreateAuthor(author);
            }

            //конвертация обновлённого DTO в контент сущность Фотография
            photoDtoUpdated.Adapt(photo);

            photo.ProductAuthor = author;

            repositoryManager.Photo.UpdatePhoto(photo);

            //сохранение изменений, если задача не была отменена
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
