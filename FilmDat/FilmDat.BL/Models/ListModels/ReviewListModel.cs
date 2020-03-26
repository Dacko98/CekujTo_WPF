using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDat.BL.Models.ListModels
{
    public class ReviewListModel : BaseModel
    {
        public Guid FilmId { get; set; }
        public uint Rating { get; set; }
    }
}
