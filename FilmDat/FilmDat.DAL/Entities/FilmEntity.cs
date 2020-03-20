﻿using System;
using System.Collections.Generic;
using FilmDat.DAL.Enums;

namespace FilmDat.DAL.Entities
{
    public class FilmEntity : EntityBase
    {
        public String OriginalName { get; set; }
        public String CzechName { get; set; }
        public GenreEnum Genre { get; set; }
        public String TitleFotoUrl { get; set; }
        public String Country { get; set; }
        public TimeSpan Duration { get; set; }
        public String Description { get; set; }
        public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
        public ICollection<DirectedFilmEntity> Directors { get; set; } = new List<DirectedFilmEntity>();
        public ICollection<ActedInFilmEntity> Actors { get; set; } = new List<ActedInFilmEntity>();

        private sealed class FilmEntityEqualityComparer : IEqualityComparer<FilmEntity>
        {
            public bool Equals(FilmEntity x, FilmEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.ID == y.ID && x.OriginalName == y.OriginalName && x.CzechName == y.CzechName && x.Genre == y.Genre && x.TitleFotoUrl == y.TitleFotoUrl && x.Country == y.Country && x.Duration.Equals(y.Duration) && x.Description == y.Description && Equals(x.Reviews, y.Reviews) && Equals(x.Directors, y.Directors) && Equals(x.Actors, y.Actors);
            }

            public int GetHashCode(FilmEntity obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.OriginalName);
                hashCode.Add(obj.CzechName);
                hashCode.Add((int) obj.Genre);
                hashCode.Add(obj.TitleFotoUrl);
                hashCode.Add(obj.Country);
                hashCode.Add(obj.Duration);
                hashCode.Add(obj.Description);
                hashCode.Add(obj.Reviews);
                hashCode.Add(obj.Directors);
                hashCode.Add(obj.Actors);
                hashCode.Add(obj.ID);
                return hashCode.ToHashCode();
            }
        }

        public static IEqualityComparer<FilmEntity> FilmEntityComparer  { get; } = new FilmEntityEqualityComparer();
    }

}