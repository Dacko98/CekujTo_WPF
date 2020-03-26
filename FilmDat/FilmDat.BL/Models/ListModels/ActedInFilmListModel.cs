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
    }
}
