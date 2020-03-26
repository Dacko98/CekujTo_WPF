using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDat.BL.Models.ListModels
{
    public class ReviewListModel : BaseModel
    {
        public Guid FilmId { get; set; }
        public uint Rating { get; set; }

        private sealed class FilmIdRatingEqualityComparer : IEqualityComparer<ReviewListModel>
        {
            public bool Equals(ReviewListModel x, ReviewListModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.FilmId.Equals(y.FilmId) && x.Rating == y.Rating;
            }

            public int GetHashCode(ReviewListModel obj)
            {
                return HashCode.Combine(obj.FilmId, obj.Rating);
            }
        }

        public static IEqualityComparer<ReviewListModel> FilmIdRatingComparer { get; } = new FilmIdRatingEqualityComparer();
    }
}
