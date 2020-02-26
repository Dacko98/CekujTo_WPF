using System;

namespace FilmDat.DAL.Entities
{
    public class ReviewsEntity : EntityBase
    {
        public String NickName { get; set; }
        public DateTime Date { get; set; }
        public uint Rating { get; set; }
        public String TextReview { get; set; }
    }
}