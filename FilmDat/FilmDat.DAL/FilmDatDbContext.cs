﻿using FilmDat.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FilmDat.DAL.Seeds;

namespace FilmDat.DAL
{
    public class FilmDatDbContext: DbContext
    {
        public FilmDatDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<FilmEntity> Films { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<ActedInFilmEntity> ActedInFilmEntities { get; set; }
        public DbSet<DirectedFilmEntity> DirectedFilmEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PersonSeeds.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
