using System;
using System.Collections.Generic;
using System.Text;
using FilmDat.BL.Factories;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Mapper
{
    internal static class ActedInFilmMapper
    {

        public static ActedInFilmListModel MapToListModel(ActedInFilmEntity entity) =>
            entity == null
                ? null
                : new ActedInFilmListModel()
                {
                    Id = entity.Id,
                    ActorId  = entity.ActorId,
                    FirstName = entity.Actor.FirstName,
                    LastName = entity.Actor.LastName,
                    FilmId = entity.FilmId,
                    OriginalName = entity.Film.OriginalName
                };

        public static ActedInFilmEntity MapToEntity(ActedInFilmListModel listModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<ActedInFilmEntity>(listModel.Id);

            entity.Id = listModel.Id;
            entity.FilmId = listModel.FilmId;
            entity.ActorId = listModel.ActorId;
            return entity;
        }
    }
}
