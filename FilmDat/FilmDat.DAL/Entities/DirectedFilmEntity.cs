using System;
using System.Collections.Generic;

namespace FilmDat.DAL.Entities
{
    public class DirectedFilmEntity : EntityBase
    {
        public Guid FilmId { get; set; }
        public Guid DirectorId { get; set; }
        public FilmEntity Film { get; set; }
        public PersonEntity Director { get; set; }

        private sealed class DirectedFilmEntityEqualityComparer : IEqualityComparer<DirectedFilmEntity>
        {
            public bool Equals(DirectedFilmEntity x, DirectedFilmEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.ID == y.ID && x.FilmId.Equals(y.FilmId) && x.DirectorId.Equals(y.DirectorId) && Equals(x.Film, y.Film) && Equals(x.Director, y.Director);
            }

            public int GetHashCode(DirectedFilmEntity obj)
            {
                return HashCode.Combine(obj.FilmId, obj.DirectorId, obj.Film, obj.Director, obj.ID);
            }
        }

        public static IEqualityComparer<DirectedFilmEntity> DirectedFilmEntityComparer { get; } = new DirectedFilmEntityEqualityComparer();
    }
}