﻿using System;

namespace FilmDat.BL.Models.ListModels
{
    public class DirectedFilmListModel : BaseModel
    {
       
        public Guid FilmId { get; set; }
        public Guid DirectorId { get; set; }
    }
}
