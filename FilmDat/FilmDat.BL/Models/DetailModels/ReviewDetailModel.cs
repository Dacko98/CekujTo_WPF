using System;
using System.Collections.Generic;
using FilmDat.BL.Models.ListModels;

namespace FilmDat.BL.Models.DetailModels
{
    public class ReviewDetailModel : BaseModel
    {
        public String NickName { get; set; }
        public DateTime Date { get; set; }
        public uint Rating { get; set; }
        public String TextReview { get; set; }
        public FilmListModel OriginalName { get; set; }

        private sealed class ReviewDetailModelEqualityComparer : IEqualityComparer<ReviewDetailModel>
        {
            public bool Equals(ReviewDetailModel x, ReviewDetailModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.NickName == y.NickName && x.Date.Equals(y.Date) && x.Rating == y.Rating &&
                       x.TextReview == y.TextReview && Equals(x.OriginalName, y.OriginalName);
            }

            public int GetHashCode(ReviewDetailModel obj)
            {
                return HashCode.Combine(obj.NickName, obj.Date, obj.Rating, obj.TextReview, obj.OriginalName);
            }
        }

        public static IEqualityComparer<ReviewDetailModel> ReviewDetailModelComparer { get; } =
            new ReviewDetailModelEqualityComparer();
    }
}
