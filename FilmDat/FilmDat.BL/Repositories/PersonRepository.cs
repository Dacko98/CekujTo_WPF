﻿using System;
using System.Collections.Generic;
using FilmDat.BL.Interfaces;
using FilmDat.BL.Mapper;
using FilmDat.BL.Models.DetailModels;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Factories;
using FilmDat.DAL.Interfaces;
using FilmDat.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmDat.BL.Repositories
{
    public class PersonRepository : RepositoryBase<PersonEntity, PersonListModel, PersonDetailModel>, IPersonRepository
    {
        public PersonRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory,
                PersonMapper.MapToEntity,
                PersonMapper.MapToListModel,
                PersonMapper.MapToDetailModel,
                new Func<PersonEntity, IEnumerable<IEntity>>[] { entity => entity.ActedInFilms },
                entities => entities
                    .Include(entity => entity.ActedInFilms)
                        .ThenInclude(entity => entity.Actor)
                    .Include(entity => entity.DirectedFilms)
                        .ThenInclude(entity => entity.Director),
                null)
        {
        }
    }
}