using System;
using System.Collections.Generic;
using System.Text;
using FilmDat.BL.Factories;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Mapper
{
    internal static class DirectedInFilmMapper
    {
        public static DirectedFilmListModel MapToListModel(DirectedFilmEntity entity) =>
            entity == null
                ? null
                : new DirectedFilmListModel()
                {
                    Id = entity.Id,
                    DirectorId = entity.DirectorId,
                    FirstName = entity.Director.FirstName,
                    LastName = entity.Director.LastName,
                    FilmId = entity.FilmId,
                    OriginalName = entity.Film.OriginalName
                };

        public static DirectedFilmEntity MapToEntity(DirectedFilmListModel listModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<DirectedFilmEntity>(listModel.Id);
            entity.Id = listModel.Id;
            entity.FilmId = listModel.FilmId;
            entity.DirectorId = listModel.DirectorId;
            entity.Film = listModel.FilmId // nevieme
            entity.Director =  // idk


            return entity;
        }
    }
}