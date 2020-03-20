using System;
using System.Collections.Generic;

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

        private sealed class ReviewEntityEqualityComparer : IEqualityComparer<ReviewEntity>
        {
            public bool Equals(ReviewEntity x, ReviewEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.ID == y.ID && x.NickName == y.NickName && x.Date.Equals(y.Date) && x.Rating == y.Rating && x.TextReview == y.TextReview && x.FilmId.Equals(y.FilmId) && Equals(x.Film, y.Film);
            }

            public int GetHashCode(ReviewEntity obj)
            {
                return HashCode.Combine(obj.NickName, obj.Date, obj.Rating, obj.TextReview, obj.FilmId, obj.Film, obj.ID);
            }
        }

        public static IEqualityComparer<ReviewEntity> ReviewEntityComparer { get; } = new ReviewEntityEqualityComparer();
    }
}