using System;
using System.Collections.Generic;
using System.Linq;
using FilmDat.BL.Models.DetailModels;
using FilmDat.BL.Repositories;
using FilmDat.BL.Mapper;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Enums;
using FilmDat.DAL.Seeds;
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
        public void Create_WithNonExistingItem_DoesNotThrow()
        {
            var model = new FilmDetailModel()
            {
                OriginalName = "The Avengers",
                Country = "USA",
                CzechName = "Avengers",
                Description = "Marvelovka",
                Genre = GenreEnum.SciFi,
                TitleFotoUrl = "avangers",
                Reviews = new List<ReviewListModel>(),
                Actors = new List<PersonListModel>(),
                Directors = new List<PersonListModel>()
            };
            var returnedModel = new FilmDetailModel();
            returnedModel = _filmRepositorySUT.InsertOrUpdate(model);
            Assert.NotNull(returnedModel);
        }
        
        [Fact]
        public void GetById_SeedFilm()
        {
            var film = _filmRepositorySUT.GetById(Seed.GreaseFilm.Id);
            Assert.Equal(FilmMapper.MapToDetailModel(Seed.GreaseFilm), film, FilmDetailModel.FilmDetailModelComparer);
        }

        [Fact]
        public void SeedFilm_DeleteByID_Deleted()
        {
            _filmRepositorySUT.Delete(Seed.GreaseFilm.Id);
            using var dbxAssert = _dbContextFactory.CreateDbContext();
            Assert.False(dbxAssert.Films.Any(i => i.Id == Seed.GreaseFilm.Id));
        }

        [Fact]
        public void NewFilm_InsertOrUpdate_FilmAdded()
        {
            var film = new FilmDetailModel()
            {
                OriginalName = "A",
                Genre = GenreEnum.Action,
                CzechName = "B",
                TitleFotoUrl = "titlefoto.png",
                Description = "A film!",
                Country = "Murica",
                Reviews = new List<ReviewListModel>(),
                Actors = new List<PersonListModel>(),
                Directors = new List<PersonListModel>()
            };
            
            film = _filmRepositorySUT.InsertOrUpdate(film);

            using var dbxAssert = _dbContextFactory.CreateDbContext();
            var filmFromDb = dbxAssert.Films.Single(i => i.Id == film.Id);
            Assert.Equal(film, FilmMapper.MapToDetailModel(filmFromDb), FilmDetailModel.FilmDetailModelComparer);
        }

        [Fact]
        public void SeedFilm_InsertOrUpdate_FilmUpdated()
        {
            var film = new FilmDetailModel()
            {
                Id = Seed.GreaseFilm.Id,
                OriginalName = Seed.GreaseFilm.OriginalName,
                Genre = Seed.GreaseFilm.Genre,
                CzechName = Seed.GreaseFilm.CzechName,
                TitleFotoUrl = Seed.GreaseFilm.TitleFotoUrl,
                Description = Seed.GreaseFilm.Description,
                Country = Seed.GreaseFilm.Country,
                Reviews = new List<ReviewListModel>(),
                Actors = new List<PersonListModel>(),
                Directors = new List<PersonListModel>()
            };
            film.OriginalName += "updated";
            _filmRepositorySUT.InsertOrUpdate(film);

            using var dbxAssert = _dbContextFactory.CreateDbContext();
            var filmFromDb = dbxAssert.Films.Single(i => i.Id == film.Id);
            Assert.Equal(film, FilmMapper.MapToDetailModel(filmFromDb), FilmDetailModel.FilmDetailModelComparer);
            film.OriginalName = "Grease";
            _filmRepositorySUT.InsertOrUpdate(film);
        }

        [Fact]
        public void GetAll_Single_SeedFilm()
        {
            var film = _filmRepositorySUT.GetAll().Single(i => i.Id == Seed.GreaseFilm.Id);

            Assert.Equal(FilmMapper.MapToListModel(Seed.GreaseFilm), film, FilmListModel.OriginalNameComparer);
        }

        public void Dispose()
        {
            using var dbx = _dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();
        }
    }
}