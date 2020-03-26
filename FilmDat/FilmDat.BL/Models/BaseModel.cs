using System;
using System.Collections.Generic;
using System.Text;
using FilmDat.DAL.Interfaces;

namespace FilmDat.BL.Models
{
    public abstract class BaseModel : IModel
    {
        public Guid Id { get; set; }
    }
}
