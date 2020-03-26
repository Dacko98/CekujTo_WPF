using System;
using System.Collections.Generic;
using System.Text;
using FilmDat.DAL.Enums;

namespace FilmDat.BL.Models.DetailModels
{
    public class FilmDetailModel:BaseModel
    {
        public String OriginalName { get; set; }
        public String CzechName { get; set; }
        public GenreEnum Genre { get; set; }
        public String TitleFotoUrl { get; set; }
        public String Country { get; set; }
        public TimeSpan Duration { get; set; }
        public String Description { get; set; }

        private sealed class FilmDetailModelEqualityComparer : IEqualityComparer<FilmDetailModel>
        {
            public bool Equals(FilmDetailModel x, FilmDetailModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.OriginalName == y.OriginalName && x.CzechName == y.CzechName && x.Genre == y.Genre && x.TitleFotoUrl == y.TitleFotoUrl && x.Country == y.Country && x.Duration.Equals(y.Duration) && x.Description == y.Description;
            }

            public int GetHashCode(FilmDetailModel obj)
            {
                return HashCode.Combine(obj.OriginalName, obj.CzechName, (int) obj.Genre, obj.TitleFotoUrl, obj.Country, obj.Duration, obj.Description);
            }
        }

        public static IEqualityComparer<FilmDetailModel> FilmDetailModelComparer { get; } = new FilmDetailModelEqualityComparer();
    }
}
