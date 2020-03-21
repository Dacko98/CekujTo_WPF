using System;
using FilmDat.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmDat.DAL.Seeds
{
    public class PersonSeeds
    {
        public static readonly PersonEntity JohnTravolta = new PersonEntity()
        {
            ID = Guid.Parse("e1e20085-1ce4-4612-be57-285b8c76d76a"),
            FirstName = "John",
            LastName = "Travolta"
        };

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonEntity>().HasData(JohnTravolta);
        }
    }
}