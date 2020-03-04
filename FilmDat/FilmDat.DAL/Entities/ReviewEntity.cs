using System;

namespace FilmDat.DAL.Entities
{
    public class ReviewEntity : EntityBase
    {
        public String NickName { get; set; }
        public DateTime Date { get; set; }
        public uint Rating { get; set; }
        public String TextReview { get; set; }
        public Guid FilmId { get; set; }
        public FilmEntity Film { get; set; }
    }
}