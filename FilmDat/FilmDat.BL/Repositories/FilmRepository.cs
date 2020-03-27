using System;
using System.Collections.Generic;
using System.Text;
using FilmDat.BL.Interfaces;
using FilmDat.BL.Mapper;
using FilmDat.BL.Models.DetailModels;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Factories;
using FilmDat.DAL.Repositories;

namespace FilmDat.BL.Repositories
{
    public class FilmRepository : RepositoryBase<FilmEntity, FilmListModel, FilmDetailModel>, IFilmRepository
    {
        public FilmRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory,
                FilmMapper.MapToEntity,
                FilmMapper.MapToListModel,
                FilmMapper.MapToDetailModel,
                null,
                null,
                null)
        {
        }
    }
}
