using System;
using System.Collections.Generic;
using System.Text;
using FilmDat.Common;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Models
{
    public abstract class BaseModel : IId
    {
        public Guid Id { get; set; }
    }
}
