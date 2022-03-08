
using System.Collections.Generic;
using System.Linq;
using Stock.Domain.Entities;
using Stock.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Stock.Persistence.Repositories
{
    internal class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryDbContext dbContext) 
            : base(dbContext) { }

        public void CreateAuthor(Author author) =>
            Create(author);

        public async Task<Author> GetAuthorByUsername(string username)
        {
            var author = await FindByCondition(author => author.Username == username).FirstOrDefaultAsync();
            return author;
        }
    }
}
