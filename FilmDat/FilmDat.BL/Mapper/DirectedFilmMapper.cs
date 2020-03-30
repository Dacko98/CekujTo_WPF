using FilmDat.BL.Factories;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace FilmDat.BL.Mapper
{
    public static class DirectedFilmMapper
    {
        public static DirectedFilmEntity MapToEntity(PersonListModel model, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<DirectedFilmEntity>(model.Id);

            entity.Id = model.Id;
            entity.Director.FirstName = model.FirstName;
            entity.Director.LastName = model.LastName;

            return entity;
        }

        public static DirectedFilmEntity MapToEntity(FilmListModel model, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<DirectedFilmEntity>(model.Id);

            entity.Id = model.Id;
            entity.Film.OriginalName = model.OriginalName;

            return entity;
        }
    }
}