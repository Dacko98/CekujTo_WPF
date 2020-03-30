using System;
using System.Collections.Generic;
using FilmDat.DAL.Enums;
using FilmDat.BL.Models.ListModels;

namespace FilmDat.BL.Models.DetailModels
{
    public class FilmDetailModel : BaseModel
    {
        public String OriginalName { get; set; }
        public String CzechName { get; set; }
        public GenreEnum Genre { get; set; }
        public String TitleFotoUrl { get; set; }
        public String Country { get; set; }
        public TimeSpan Duration { get; set; }
        public String Description { get; set; }
        public ICollection<PersonListModel> Actors { get; set; }
        public ICollection<PersonListModel> Directors { get; set; }
        public ICollection<ReviewListModel> Reviews { get; set; }

        private sealed class FilmDetailModelEqualityComparer : IEqualityComparer<FilmDetailModel>
        {
            public bool Equals(FilmDetailModel x, FilmDetailModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.OriginalName == y.OriginalName && x.CzechName == y.CzechName && x.Genre == y.Genre && x.TitleFotoUrl == y.TitleFotoUrl && x.Country == y.Country && x.Duration.Equals(y.Duration) && x.Description == y.Description && Equals(x.Actors, y.Actors) && Equals(x.Directors, y.Directors) && Equals(x.Reviews, y.Reviews);
            }

            public int GetHashCode(FilmDetailModel obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.OriginalName);
                hashCode.Add(obj.CzechName);
                hashCode.Add((int) obj.Genre);
                hashCode.Add(obj.TitleFotoUrl);
                hashCode.Add(obj.Country);
                hashCode.Add(obj.Duration);
                hashCode.Add(obj.Description);
                hashCode.Add(obj.Actors);
                hashCode.Add(obj.Directors);
                hashCode.Add(obj.Reviews);
                return hashCode.ToHashCode();
            }
        }

        public static IEqualityComparer<FilmDetailModel> FilmDetailModelComparer { get; } = new FilmDetailModelEqualityComparer();
    }
}
