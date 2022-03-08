
using Stock.Domain.Interfaces;
using System.Collections.Generic;

namespace Stock.Persistence.Repositories
{
    /// <summary>
    /// Определяет контекст данных во всех других репозиториях и инициализирует их экземпляры
    /// </summary>
    public class RepositoryManager : IRepositoryManager
    {
        public RepositoryManager(RepositoryDbContext dbContext)
        {
            lazyText = new Lazy<ITextRepository>(() => new TextRepository(dbContext));
            lazyPhoto = new Lazy<IPhotoRepository>(() => new PhotoRepository(dbContext));
            lazyAuthor = new Lazy<IAuthorRepository>(() => new AuthorRepository(dbContext));
            lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        private readonly Lazy<ITextRepository> lazyText;
        public ITextRepository Text => lazyText.Value;


        private readonly Lazy<IPhotoRepository> lazyPhoto;
        public IPhotoRepository Photo => lazyPhoto.Value;


        private readonly Lazy<IAuthorRepository> lazyAuthor;
        public IAuthorRepository Author => lazyAuthor.Value;


        private readonly Lazy<IUnitOfWork> lazyUnitOfWork;
        public IUnitOfWork UnitOfWork => lazyUnitOfWork.Value;
    }
}
