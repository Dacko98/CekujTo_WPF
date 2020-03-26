using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using FilmDat.BL.Factories;
using FilmDat.BL.Models.DetailModels;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Mapper
{
    internal static class ReviewMapper
    {
        public static ReviewEntity MapToEntity(ReviewListModel listModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<ReviewEntity>(listModel.Id);
            return entity;
        }
    }
}
