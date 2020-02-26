﻿using System;

namespace FilmDat.DAL.Entities
{
    public class ActedInFilmsEntity : EntityBase
    {
        public Guid FilmId { get; set; }
        public Guid ActorId { get; set; }
        public FilmEntity Film { get; set; }
        public PersonEntity Actor { get; set; }
    }
}