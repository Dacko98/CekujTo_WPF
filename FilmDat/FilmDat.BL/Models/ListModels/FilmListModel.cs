﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDat.BL.Models.ListModels
{
     public class FilmListModel : BaseModel
    {
        public Guid ID { get; set; }
        public string OriginalName { get; set; }
    }
}
