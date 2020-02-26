﻿using System;

namespace FilmDat.DAL.Entities
{
    public class DirectedFilmsEntity : EntityBase
    {
        public Guid FilmId { get; set; }
        public Guid DirectorId { get; set; }
        public FilmEntity Film { get; set; }
        public PersonEntity Director { get; set; }
    }
}