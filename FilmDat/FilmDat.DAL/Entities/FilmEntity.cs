using System;
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
    }
}