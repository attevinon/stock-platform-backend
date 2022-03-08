using Stock.Domain.Entities;
using Stock.Domain.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Stock.Persistence.Repositories
{
    internal class TextRepository : GenericProductRepository<Text>, ITextRepository
    {
        public TextRepository(RepositoryDbContext dbContext) 
            : base(dbContext) { }

        public async Task<IEnumerable<Text>> GetAllTextsAsync()
        {
            var texts = await FindAllWithOwner(text => text.ProductAuthor).ToListAsync();
            return texts;
        }

        public async Task<Text> GetTextByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var text = await FindByConditionWithOwner(text => text.Id.Equals(id), text => text.ProductAuthor)
                .FirstOrDefaultAsync(cancellationToken);
            return text;
        }

        public void CreateText(Text text)
        {
            //Отменяет создание новой сущности Автор
            DbContext.Entry(text.ProductAuthor).State = EntityState.Unchanged;

            Create(text);
        }
    }
}
