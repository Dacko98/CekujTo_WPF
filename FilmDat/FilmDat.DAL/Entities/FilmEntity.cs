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
        public String TitleFoto { get; set; }
        public String Country { get; set; }
        public TimeSpan Duration { get; set; }
        public String Description { get; set; }
        public ICollection<ReviewsEntity> Reviews { get; set; } = new List<ReviewsEntity>();
        public ICollection<DirectedFilmsEntity> Directors { get; set; } = new List<DirectedFilmsEntity>();
        public ICollection<ActedInFilmsEntity> Actors { get; set; } = new List<ActedInFilmsEntity>();
    }
}