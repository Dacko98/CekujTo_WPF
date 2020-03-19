using FilmDat.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xunit;
using FilmDat.DAL.Enums;
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
        }

        [Fact]
        public void AddNew_Person_Persisted()
        {
            var personEntity = new PersonEntity()
            {
                FirstName = "Ján",
                LastName = "Mikulec",
                BirthDate = new DateTime(1987,11,10),
                Foto = "fotka.jpg",
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
               Assert.Equal(personEntity.Foto, fromDb.Foto);
                //ssert.Equal(personEntity, fromDb, PersonEntity.PersonEntityComparer);
            }
            
       
        }

        public void Dispose() => _filmDatDbContext?.Dispose();
    }
}
 