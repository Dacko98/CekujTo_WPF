using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDat.BL.Models.ListModels
{
    public class ActedInFilmListModel:BaseModel
    {
        
        public Guid FilmId { get; set; }
        public Guid ActorId { get; set; }
    }
}
