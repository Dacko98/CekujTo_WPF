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
            /*entity.Actor = (entityFactory ??= new CreateNewEntityFactory()).Create<PersonEntity>(model.Id);
            entity.Actor.FirstName = model.FirstName;
            entity.Actor.LastName = model.LastName;*/

            return entity;
        }

        public static ActedInFilmEntity MapToEntity(FilmListModel model, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<ActedInFilmEntity>(model.Id);

            entity.Id = model.Id;
            /*entity.Film.OriginalName = model.OriginalName;*/

            return entity;
        }
    }
}