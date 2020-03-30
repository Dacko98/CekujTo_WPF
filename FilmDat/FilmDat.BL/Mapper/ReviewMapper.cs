﻿using FilmDat.BL.Factories;
using FilmDat.BL.Models.DetailModels;
using FilmDat.BL.Models.ListModels;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Mapper
{
    public static class ReviewMapper
    {
        public static ReviewListModel MapToListModel(ReviewEntity entity) =>
            entity == null
                ? null
                : new ReviewListModel()
                {
                    Id = entity.Id,
                    Rating = entity.Rating
                };

        public static ReviewDetailModel MapToDetailModel(ReviewEntity entity) =>
            entity == null
                ? null
                : new ReviewDetailModel()
                {
                    Id = entity.Id,
                    NickName = entity.NickName,
                    Date = entity.Date,
                    Rating = entity.Rating,
                    TextReview = entity.TextReview,
                };

        public static ReviewEntity MapToEntity(ReviewDetailModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<ReviewEntity>(detailModel.Id);

            entity.Id = detailModel.Id;
            entity.Date = detailModel.Date;
            entity.Rating = detailModel.Rating;
            entity.TextReview = detailModel.TextReview;
            entity.NickName = detailModel.TextReview;

            return entity;
        }

        public static ReviewEntity MapToEntity(ReviewListModel model, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<ReviewEntity>(model.Id);

            entity.Rating = model.Rating;
            entity.TextReview = model.TextReview;

            return entity;
        }
    }
}