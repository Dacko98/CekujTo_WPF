using System;
using System.Collections.Generic;

namespace FilmDat.BL.Models.ListModels
{
    public class DirectedFilmListModel : BaseModel
    {
        public Guid DirectorId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Guid FilmId { get; set; }
        public String OriginalName { get; set; }

        private sealed class DirectedFilmListModelEqualityComparer : IEqualityComparer<DirectedFilmListModel>
        {
            public bool Equals(DirectedFilmListModel x, DirectedFilmListModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.DirectorId.Equals(y.DirectorId) && x.FirstName == y.FirstName && x.LastName == y.LastName && x.FilmId.Equals(y.FilmId) && x.OriginalName == y.OriginalName;
            }

            public int GetHashCode(DirectedFilmListModel obj)
            {
                return HashCode.Combine(obj.DirectorId, obj.FirstName, obj.LastName, obj.FilmId, obj.OriginalName);
            }
        }

        public static IEqualityComparer<DirectedFilmListModel> DirectedFilmListModelComparer { get; } = new DirectedFilmListModelEqualityComparer();
    }
}
