using Stock.Domain.Entities;
using Stock.Domain.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Stock.Persistence.Repositories
{
    internal class PhotoRepository : GenericProductRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(RepositoryDbContext dbContext) 
            : base(dbContext) { }

        public async Task<IEnumerable<Photo>> GetAllPhotosAsync()
        {
            var photos = await FindAllWithOwner(photo => photo.ProductAuthor).ToListAsync();
            return photos;
        }

        public async Task<Photo> GetPhotoByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var photo = await FindByConditionWithOwner(photo => photo.Id.Equals(id), photo => photo.ProductAuthor)
                .FirstOrDefaultAsync(cancellationToken);
            return photo;
        }

        public void UpdatePhoto(Photo photo)
        {
            DbContext.Set<Photo>().Update(photo);

            DbContext.Entry(photo).State = EntityState.Modified;
        }
    }
}
