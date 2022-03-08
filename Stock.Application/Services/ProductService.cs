using Mapster;
using Stock.Application.Contracts;
using Stock.Application.Service.Interfaces;
using Stock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Services
{
    /// <summary>
    /// Представляет логику взаимодействия клиента с контент сущностями (продуктами)
    /// </summary>

    public class ProductService : IProductsService
    {
        //обеспечивает взаимодейтсвие Application с репозиториями (и => базой данных)
        private readonly IRepositoryManager repositoryManager;

        /// <summary>
        /// Конструктор устанавливает репозиторий для взаимодействия с базой данных
        /// </summary>
        /// <param name="repositoryManager"></param>
        public ProductService(IRepositoryManager repositoryManager) 
            => this.repositoryManager = repositoryManager;


        public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            //поиск всех контент сущностей Фотография в базе данных и их конвертация
            var photos = await repositoryManager.Photo.GetAllPhotosAsync();
            var photosDto = photos.Adapt<IEnumerable<PhotoDto>>();

            //поиск всех контент сущностей Текст в базе данных и их конвертация
            var texts = await repositoryManager.Text.GetAllTextsAsync();
            var textsDto = texts.Adapt<IEnumerable<TextDto>>();

            //создание общего списка всех контент сущностей (продуктов) и его инициализация
            var products = new List<ProductDto>();
            products.AddRange(photosDto);
            products.AddRange(textsDto);

            return products;
        }
    }
}
