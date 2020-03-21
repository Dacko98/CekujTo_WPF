using FilmDat.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xunit;
using FilmDat.DAL.Enums;
using FilmDat.DAL.Seeds;

namespace FilmDat.DAL.Tests
{
    public class FilmDatDbContextTests : IDisposable
    {
        private readonly DbContextInMemoryFactory _dbContextfactory;
        private readonly FilmDatDbContext _filmDatDbContext;

        public FilmDatDbContextTests()
        {
            _dbContextfactory = new DbContextInMemoryFactory(nameof(FilmDatDbContext));
            _filmDatDbContext = _dbContextfactory.Create();
            _filmDatDbContext.Database.EnsureCreated();
        }

        [Fact]
        public void AddNew_Person_Persisted()
        {
            var personEntity = new PersonEntity()
            {
                FirstName = "Ján",
                LastName = "Mikulec",
                BirthDate = new DateTime(1987,11,10),
                FotoUrl = "fotka.jpg",
            };
           
            _filmDatDbContext.Persons.Add(personEntity);
            _filmDatDbContext.SaveChanges();

            using (var dbx = _dbContextfactory.Create())
            {
                var fromDb = dbx.Persons.Single(i => i.ID == personEntity.ID);
                // da sa to bud comparer alebo   
               Assert.Equal(personEntity.FirstName, fromDb.FirstName);
               Assert.Equal(personEntity.LastName, fromDb.LastName);
               Assert.Equal(personEntity.BirthDate, fromDb.BirthDate);
               Assert.Equal(personEntity.FotoUrl, fromDb.FotoUrl);
                //ssert.Equal(personEntity, fromDb, PersonEntity.PersonEntityComparer);
            }
        }

        [Fact]
        public void GetAll_Persons()
        {
            var fromDb = _filmDatDbContext.Persons.Single(i=>i.ID == PersonSeeds.JohnTravolta.ID);
            //  Assert.NotEmpty(_filmDatDbContext.Persons.ToArray());
        }

        public void Dispose() => _filmDatDbContext?.Dispose();
    }
}
 