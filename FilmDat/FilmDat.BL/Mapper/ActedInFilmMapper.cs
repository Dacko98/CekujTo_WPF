using FilmDat.BL.Factories;
using FilmDat.BL.Models.DetailModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Mapper
{
    internal static class ActedInFilmMapper
    {

        public static ActedInFilmDetailModel MapToListModel(ActedInFilmEntity entity) =>
            entity == null
                ? null
                : new ActedInFilmDetailModel()
                {
                    Id = entity.Id,
                    ActorId  = entity.ActorId,
                    FirstName = entity.Actor.FirstName,
                    LastName = entity.Actor.LastName,
                    FilmId = entity.FilmId,
                    OriginalName = entity.Film.OriginalName
                };

        public static ActedInFilmEntity MapToEntity(ActedInFilmDetailModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<ActedInFilmEntity>(detailModel.Id);

            entity.Id = detailModel.Id;
            entity.FilmId = detailModel.FilmId;
            entity.ActorId = detailModel.ActorId;

            return entity;
        }
    }
}
