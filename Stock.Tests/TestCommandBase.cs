using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock.Persistence;
using Stock.Domain.Models;
using System;

namespace Stock.Tests
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly RepositoryDbContext Context;

        public TestCommandBase()
        {
            Context = StockContextFactory.Create();
        }

        public void Dispose()
        {
            StockContextFactory.Destroy(Context);
        }
    }
}
