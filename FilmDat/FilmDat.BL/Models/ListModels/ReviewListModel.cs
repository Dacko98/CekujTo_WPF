using System;
using System.Collections.Generic;

namespace FilmDat.BL.Models.ListModels
{
    public class ReviewListModel : BaseModel
    {
        public uint Rating { get; set; }
        public String TextReview { get; set; }

        private sealed class RatingTextReviewEqualityComparer : IEqualityComparer<ReviewListModel>
        {
            public bool Equals(ReviewListModel x, ReviewListModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Rating == y.Rating && x.TextReview == y.TextReview;
            }

            public int GetHashCode(ReviewListModel obj)
            {
                return HashCode.Combine(obj.Rating, obj.TextReview);
            }
        }

        public static IEqualityComparer<ReviewListModel> RatingTextReviewComparer { get; } =
            new RatingTextReviewEqualityComparer();
    }
}