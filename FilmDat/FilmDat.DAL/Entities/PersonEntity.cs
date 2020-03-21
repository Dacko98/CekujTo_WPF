using System;
using System.Collections.Generic;

namespace FilmDat.DAL.Entities
{
    public class PersonEntity : EntityBase
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String FotoUrl { get; set; }
        public ICollection<DirectedFilmEntity> DirectedFilms { get; set; } = new List<DirectedFilmEntity>();
        public ICollection<ActedInFilmEntity> ActedInFilms { get; set; } = new List<ActedInFilmEntity>();

        private sealed class PersonEntityEqualityComparer : IEqualityComparer<PersonEntity>
        {
            public bool Equals(PersonEntity x, PersonEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.ID == y.ID && x.FirstName == y.FirstName && x.LastName == y.LastName && x.BirthDate.Equals(y.BirthDate) && x.FotoUrl == y.FotoUrl && Equals(x.DirectedFilms, y.DirectedFilms) && Equals(x.ActedInFilms, y.ActedInFilms);
            }

            public int GetHashCode(PersonEntity obj)
            {
                return HashCode.Combine(obj.FirstName, obj.LastName, obj.BirthDate, obj.FotoUrl, obj.DirectedFilms, obj.ActedInFilms, obj.ID);
            }
        }

        public static IEqualityComparer<PersonEntity> PersonEntityComparer { get; } = new PersonEntityEqualityComparer();
    }
}