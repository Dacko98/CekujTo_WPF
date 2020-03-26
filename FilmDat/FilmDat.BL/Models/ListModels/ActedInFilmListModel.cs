using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDat.BL.Models.ListModels
{
    public class ActedInFilmListModel:BaseModel
    {
        public Guid ActorId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Guid FilmId { get; set; }
        public String OriginalName { get; set; }

        private sealed class ActedInFilmListModelEqualityComparer : IEqualityComparer<ActedInFilmListModel>
        {
            public bool Equals(ActedInFilmListModel x, ActedInFilmListModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.ActorId.Equals(y.ActorId) && x.FirstName == y.FirstName && x.LastName == y.LastName && x.FilmId.Equals(y.FilmId) && x.OriginalName == y.OriginalName;
            }

            public int GetHashCode(ActedInFilmListModel obj)
            {
                return HashCode.Combine(obj.ActorId, obj.FirstName, obj.LastName, obj.FilmId, obj.OriginalName);
            }
        }

        public static IEqualityComparer<ActedInFilmListModel> ActedInFilmListModelComparer { get; } = new ActedInFilmListModelEqualityComparer();
    }
}
