﻿using FilmDat.DAL;
using FilmDat.DAL.Factories;
using Microsoft.EntityFrameworkCore;


namespace FilmDat.BL.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        public FilmDatDbContext CreateDbContext()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<FilmDatDbContext>();
            dbContextOptionsBuilder.UseSqlServer(
                @"Data Source = (LocalDB)\MSSQLLocalDB;
                Initial Catalog = FilmDat2;
                MultipleActiveResultSets = True;
                Integrated Security = True;");
            return new FilmDatDbContext(dbContextOptionsBuilder.Options);
        }
    }
}