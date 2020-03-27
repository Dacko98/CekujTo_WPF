using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FilmDat.BL.Factories;
using FilmDat.BL.Models.DetailModels;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Enums;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Mapper
{
    internal static class PersonMapper
    {
        public static PersonListModel MapToListModel(PersonEntity entity) =>
            entity == null
                ? null
                : new PersonListModel()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName
                };

        public static PersonDetailModel MapToDetailModel(PersonEntity entity) =>
            entity == null
                ? null
                : new PersonDetailModel
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    BirthDate = entity.BirthDate,
                    FotoUrl = entity.FotoUrl,
                 
                    ActedInFilms = entity.ActedInFilms.Select(
                        PersonEntity => new ActedInFilmListModel()
                        {
                            Id = PersonEntity.Id,
                            ActorId = entity.Id,
                            FilmId = PersonEntity.FilmId,
                            FirstName = PersonEntity.Actor.FirstName,
                            LastName = PersonEntity.Actor.LastName
                        }).ToList(),
                    DirectedFilms = entity.DirectedFilms.Select(
                        PersonEntity => new DirectedFilmListModel()
                        {
                            Id = PersonEntity.Id,
                            DirectorId = entity.Id,
                            FilmId = PersonEntity.FilmId,
                            FirstName = PersonEntity.Director.FirstName,
                            LastName = PersonEntity.Director.LastName
                        }).ToList(),
                    
                };

        public static PersonEntity MapToEntity(PersonDetailModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<PersonEntity>(detailModel.Id);
            entity.Id = detailModel.Id;
            entity.FirstName = detailModel.FirstName;
            entity.LastName = detailModel.LastName;
            entity.BirthDate = detailModel.BirthDate;
            entity.FotoUrl = detailModel.FotoUrl;
            entity.DirectedFilms = detailModel.DirectedFilms.Select(detailModel => DirectedInFilmMapper.MapToEntity(detailModel, entityFactory)).ToList();
            entity.ActedInFilms = detailModel.ActedInFilms.Select(detailModel => ActedInFilmMapper.MapToEntity(detailModel, entityFactory)).ToList();
            
            return entity;
        }
    }
}
