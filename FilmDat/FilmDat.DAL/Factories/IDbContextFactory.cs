using Microsoft.EntityFrameworkCore;

namespace FilmDat.DAL.Factories
{
    public interface IDbContextFactory<out TDbContext > where TDbContext: DbContext
    {
        TDbContext Create();
    }
}