using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FilmDat.DAL.Factories
{
    public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<FilmDatDbContext>
    {
        public FilmDatDbContext CreateDbContext(string[] args)
        {
            
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<FilmDatDbContext>();
            dbContextOptionsBuilder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                                Initial Catalog = FilmDat;
                                MultipleActiveResultSets = True;
                                Integrated Security = True; ");
            return new FilmDatDbContext(dbContextOptionsBuilder.Options);
        }
    }
}