﻿using System.Linq;
using FilmDat.BL.Factories;
using FilmDat.BL.Models.DetailModels;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Mapper
{
    public static class PersonMapper
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
                        FilmEntity => new FilmListModel()
                        {
                            Id = FilmEntity.Id,
                            OriginalName = FilmEntity.Film.OriginalName
                        }).ToList(),

                    DirectedFilms = entity.DirectedFilms.Select(
                        FilmEntity => new FilmListModel()
                        {
                            Id = FilmEntity.Id,
                            OriginalName = FilmEntity.Film.OriginalName
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

            entity.DirectedFilms = detailModel.DirectedFilms.Select(model => DirectedFilmMapper.MapToEntity(model, entityFactory)).ToList();
            entity.ActedInFilms = detailModel.ActedInFilms.Select(model => ActedInFilmMapper.MapToEntity(model, entityFactory)).ToList();

            return entity;
        }
    }
}
