namespace FilmDat.DAL.Factories
{
    public interface IDbContextFactory
    {
       FilmDatDbContext CreateDbContext();
    }
}