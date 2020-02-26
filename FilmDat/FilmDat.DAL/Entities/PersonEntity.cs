using System;

namespace FilmDat.DAL.Entities
{
    public class PersonEntity : EntityBase
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String Foto { get; set; }
    }
}