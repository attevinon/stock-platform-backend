using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Application.Contracts;
using Stock.Application.Service.Interfaces;
using Stock.Domain.Interfaces;
using Stock.Domain.Entities;


namespace Stock.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITextService> lazyTextService;
        private readonly Lazy<IPhotoService> lazyPhotographyService;
        private readonly Lazy<IProductsService> lazyProductService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            lazyTextService = new Lazy<ITextService>(() => new TextService(repositoryManager));
            lazyPhotographyService = new Lazy<IPhotoService>(() => new PhotoService(repositoryManager));
            lazyProductService = new Lazy<IProductsService>(() => new ProductService(repositoryManager));

            CustomMapping customMapping = new();
            customMapping.SetCustomAuthorMapping();
        }

        public ITextService TextService => lazyTextService.Value;
        public IPhotoService PhotoService => lazyPhotographyService.Value;
        public IProductsService ProductService => lazyProductService.Value;
    }
}
