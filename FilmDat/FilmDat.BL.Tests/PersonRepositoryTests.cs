using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FilmDat.BL.Mapper;
using FilmDat.BL.Models.DetailModels;
using FilmDat.BL.Models.ListModels;
using FilmDat.BL.Repositories;
using FilmDat.DAL.Seeds;
using Xunit;

namespace FilmDat.BL.Tests
{
    public class PersonRepositoryTests : IDisposable
    {
        private readonly PersonRepository _personRepositorySUT;
        private readonly DbContextInMemoryFactory _dbContextFactory;

        public PersonRepositoryTests()
        {
            _dbContextFactory = new DbContextInMemoryFactory(nameof(PersonRepositoryTests));
            using var dbx = _dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();
            _personRepositorySUT = new PersonRepository(_dbContextFactory);
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrow()
        {
            var model = new PersonDetailModel()
            {
                FirstName = "Jan",
                LastName = "Testovaci",
                BirthDate = new DateTime(1979, 10, 27),
                FotoUrl = "fotka",
                ActedInFilms = { },
                DirectedFilms = { }
            };
            var returnmodel = _personRepositorySUT.InsertOrUpdate(model);
            Assert.NotNull(returnmodel);
        }

        [Fact]
        public void GetAll_Single_SeedPerson()
        {
            var person = _personRepositorySUT.GetAll().Single(i => i.Id == Seed.JohnTravolta.Id);
            Assert.Equal(PersonMapper.MapToListModel(Seed.JohnTravolta),person,PersonListModel.FirstNameLastNameComparer);
        }

        [Fact]
        public void GetById_SeededPerson()
        {
            var person = _personRepositorySUT.GetById(Seed.JohnTravolta.Id);
            Assert.Equal(PersonMapper.MapToDetailModel(Seed.JohnTravolta),person,PersonDetailModel.PersonDetailModelComparer);
        }

        [Fact]
        public void SeededPerosn_DeleteById_Deleted()
        {
            _personRepositorySUT.Delete(Seed.JohnTravolta.Id);
            using var dbxAssert = _dbContextFactory.CreateDbContext();
            Assert.False(dbxAssert.Persons.Any(i => i.Id == Seed.JohnTravolta.Id));
        }

        [Fact]
        public void NewPerson_InsertOrUpdate_PersonAdded()
        {
            var person = new PersonDetailModel()
            {
                FirstName = "test",
                LastName = "testovaci",
                BirthDate = new DateTime(1989, 12, 12),
                FotoUrl = "foto",
                ActedInFilms =
                {
                    new FilmListModel()
                    {
                        
                        OriginalName = "Rambo 5"
                    }
                },
                DirectedFilms =
                {
                    new FilmListModel()
                    {
                       
                        OriginalName = "Rambo 5"
                    }
                }
            };
            person = _personRepositorySUT.InsertOrUpdate(person);
            using var dbxAssert = _dbContextFactory.CreateDbContext();
            var personFromDb = dbxAssert.Persons.Single(i => i.Id == person.Id);
            Assert.Equal(person,PersonMapper.MapToDetailModel(personFromDb),PersonDetailModel.PersonDetailModelComparer);
        }

        [Fact]
        public void SeededPerson_InsertOrUpdate_PersonUpdated()
        {
            var person = new PersonDetailModel()
            {
                Id = Seed.JohnTravolta.Id,
                FirstName = Seed.JohnTravolta.FirstName,
                LastName = Seed.JohnTravolta.FirstName,
            };
            person.FirstName += "updated";
            person.LastName += "updated";

            _personRepositorySUT.InsertOrUpdate(person);
            using var dbxAssert = _dbContextFactory.CreateDbContext();
            var personFromDb = dbxAssert.Persons.Single(i => i.Id == person.Id);
            Assert.Equal(person, PersonMapper.MapToDetailModel(personFromDb),PersonDetailModel.PersonDetailModelComparer);
        }
        

        public void Dispose()
        {
            using var dbx = _dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();
        }
    }
}