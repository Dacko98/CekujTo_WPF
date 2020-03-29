using FilmDat.BL.Factories;
using FilmDat.BL.Models.DetailModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Mapper
{
    internal static class DirectedInFilmMapper
    {
        public static DirectedFilmDetailModel MapToListModel(DirectedFilmEntity entity) =>
            entity == null
                ? null
                : new DirectedFilmDetailModel()
                {
                    Id = entity.Id,
                    DirectorId = entity.DirectorId,
                    FirstName = entity.Director.FirstName,
                    LastName = entity.Director.LastName,
                    FilmId = entity.FilmId,
                    OriginalName = entity.Film.OriginalName
                };

        public static DirectedFilmEntity MapToEntity(DirectedFilmDetailModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<DirectedFilmEntity>(detailModel.Id);

            entity.Id = detailModel.Id;
            entity.FilmId = detailModel.FilmId;
            entity.DirectorId = detailModel.DirectorId;

            return entity;
        }
    }
}