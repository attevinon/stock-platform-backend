using Stock.Domain.Interfaces;

namespace Stock.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private RepositoryDbContext dbContext;

        public UnitOfWork(RepositoryDbContext dbContext) =>
            this.dbContext = dbContext;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}