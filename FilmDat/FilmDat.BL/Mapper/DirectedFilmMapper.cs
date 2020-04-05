using FilmDat.BL.Factories;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Mapper
{
    public static class DirectedFilmMapper
    {
        public static DirectedFilmEntity MapToEntity(PersonListModel model, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<DirectedFilmEntity>(model.Id);

            entity.Id = model.Id;

            return entity;
        }

        public static DirectedFilmEntity MapToEntity(FilmListModel model, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<DirectedFilmEntity>(model.Id);

            entity.Id = model.Id;

            return entity;
        }
    }
}