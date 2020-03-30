using System.Linq;
using FilmDat.BL.Factories;
using FilmDat.BL.Models.DetailModels;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Enums;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Mapper
{
    public static class FilmMapper
    {
        public static FilmListModel MapToListModel(FilmEntity entity) =>
            entity == null
                ? null
                : new FilmListModel
                {
                    Id = entity.Id,
                    OriginalName = entity.OriginalName
                };

        public static FilmDetailModel MapToDetailModel(FilmEntity entity) =>
            entity == null
                ? null
                : new FilmDetailModel
                {
                    Id = entity.Id,
                    OriginalName = entity.OriginalName,
                    CzechName = entity.CzechName,
                    Genre = (GenreEnum) entity.Genre,
                    TitleFotoUrl = entity.TitleFotoUrl,
                    Country = entity.Country,
                    Duration = entity.Duration,
                    Description = entity.Description,

                    Actors = entity.Actors.Select(
                        PersonEntity => new PersonListModel()
                        {
                            Id = PersonEntity.Id,
                            FirstName = PersonEntity.Actor.FirstName,
                            LastName = PersonEntity.Actor.LastName
                        }).ToList(),

                    Directors = entity.Directors.Select(
                        PersonEntity => new PersonListModel()
                        {
                            Id = PersonEntity.Id,
                            FirstName = PersonEntity.Director.FirstName,
                            LastName = PersonEntity.Director.LastName
                        }).ToList(),

                    Reviews = entity.Reviews.Select(
                        ReviewEntity => new ReviewListModel()
                        {
                            Id = ReviewEntity.Id,
                            Rating = ReviewEntity.Rating
                        }).ToList()
                };

        public static FilmEntity MapToEntity(FilmDetailModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<FilmEntity>(detailModel.Id);

            entity.Id = detailModel.Id;
            entity.OriginalName = detailModel.OriginalName;
            entity.CzechName = detailModel.CzechName;
            entity.Genre = (GenreEnum) detailModel.Genre;
            entity.TitleFotoUrl = detailModel.TitleFotoUrl;
            entity.Country = detailModel.Country;
            entity.Duration = detailModel.Duration;
            entity.Description = detailModel.Description;

            entity.Reviews = detailModel.Reviews.Select(model => ReviewMapper.MapToEntity(model, entityFactory))
                .ToList();
            entity.Actors = detailModel.Actors.Select(model => ActedInFilmMapper.MapToEntity(model, entityFactory))
                .ToList();
            entity.Directors = detailModel.Directors
                .Select(model => DirectedFilmMapper.MapToEntity(model, entityFactory)).ToList();

            return entity;
        }
    }
}