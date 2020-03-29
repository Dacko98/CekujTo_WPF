using System;
using FilmDat.BL.Repositories;
using Xunit;

namespace FilmDat.BL.Tests
{
    public class FilmRepositoryTests : IDisposable
    {
        private readonly FilmRepository _filmRepositorySUT;
        private readonly DbContextInMemoryFactory _dbContextFactory;

        public FilmRepositoryTests()
        {
            _dbContextFactory = new DbContextInMemoryFactory(nameof(FilmRepositoryTests));
            using var dbx = _dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();

            _filmRepositorySUT = new FilmRepository(_dbContextFactory);
        }

        [Fact]
        public void Test1()
        {

        }

        public void Dispose()
        {
            using var dbx = _dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();
        }
    }
}
