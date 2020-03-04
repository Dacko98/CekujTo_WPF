using System;
using System.Collections.Generic;

namespace FilmDat.DAL.Entities
{
    public class PersonEntity : EntityBase
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String Foto { get; set; }
        public ICollection<DirectedFilmEntity> DirectedFilms { get; set; } = new List<DirectedFilmEntity>();
        public ICollection<ActedInFilmEntity> ActedInFilms { get; set; } = new List<ActedInFilmEntity>();
    }
}