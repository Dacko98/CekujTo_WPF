using FilmDat.BL.Factories;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Mapper
{
    public static class ActedInFilmMapper
    {
        public static ActedInFilmEntity MapToEntity(PersonListModel model, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<ActedInFilmEntity>(model.Id);

            entity.Id = model.Id;

            return entity;
        }

        public static ActedInFilmEntity MapToEntity(FilmListModel model, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<ActedInFilmEntity>(model.Id);

            entity.Id = model.Id;

            return entity;
        }
    }
}