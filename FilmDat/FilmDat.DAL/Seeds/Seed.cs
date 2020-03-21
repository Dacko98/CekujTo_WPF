using System;
using System.Collections.Generic;
using FilmDat.DAL.Entities;
using FilmDat.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace FilmDat.DAL.Seeds
{
    public static class Seed
    {
        public static readonly PersonEntity JohnTravolta = new PersonEntity()
        {
            ID = Guid.Parse("e1e20085-1ce4-4612-be57-285b8c76d76a"),
            FirstName = "John",
            LastName = "Travolta",
            BirthDate = new DateTime(1972,11,12),
            FotoUrl = "johntravolta.jpg",
            DirectedFilms = new List<DirectedFilmEntity>(),
            ActedInFilms = new List<ActedInFilmEntity>()
        };

        public static readonly FilmEntity GreaseFilm = new FilmEntity()
        {
            ID = Guid.Parse("088e40b8-63f6-4089-bfa9-4146e36e888c"),
            OriginalName = "Grease",
            CzechName = "Pomada",
            Genre = GenreEnum.Romance,
            TitleFotoUrl = "pomada.jpg",
            Country = "USA",
            Duration = new TimeSpan(2,0,0),
            Description = "Romanticky muzikal",
            Reviews =  new List<ReviewEntity>(),
            Directors = new List<DirectedFilmEntity>(),
            Actors = new List<ActedInFilmEntity>()
        };

        public static readonly ReviewEntity FilmReviews = new ReviewEntity()
        {
            ID = Guid.Parse("585b8ad0-aa06-49dd-94fd-8ab6c93f7e57"),
            NickName = "Alan232",
            Date = new DateTime(2013, 6, 5),
            Rating = 82,
            TextReview = "Skvely film plny tanca a zabavy",
            FilmId = GreaseFilm.ID,
            Film = GreaseFilm
        };

        public static readonly PersonEntity RandalKleiser = new PersonEntity()
        {
            ID = Guid.Parse("6d372469-af50-4cfe-9582-8789bf598b2b"),
            FirstName = "Randal",
            LastName = "Kleiser",
            BirthDate = new DateTime(1972, 11, 12),
            FotoUrl = "randalklieser.jpg",
            DirectedFilms = new List<DirectedFilmEntity>(),
            ActedInFilms = new List<ActedInFilmEntity>()
        };

        public static readonly ActedInFilmEntity JohnTravoltaFilm = new ActedInFilmEntity()
        {
            ID = Guid.Parse("501744f2-4fc1-494b-8b84-5fecb9f7903d"),
            FilmId = GreaseFilm.ID,
            ActorId = JohnTravolta.ID,
            Film = GreaseFilm,
            Actor = JohnTravolta
        };

        public static readonly DirectedFilmEntity RandalKleiserFilm = new DirectedFilmEntity()
        {
            ID = Guid.Parse("75cb065e-643a-4b6f-807f-b3add4cf0eca"),
            FilmId = GreaseFilm.ID,
            DirectorId = RandalKleiser.ID,
            Film = GreaseFilm,
            Director = RandalKleiser
        };

        static Seed()
        {
            JohnTravolta.ActedInFilms.Add(JohnTravoltaFilm);
            GreaseFilm.Reviews.Add(FilmReviews);
            GreaseFilm.Actors.Add(JohnTravoltaFilm);
            GreaseFilm.Directors.Add(RandalKleiserFilm);
            RandalKleiser.DirectedFilms.Add(RandalKleiserFilm);
        }
        public static void SeedPerson(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonEntity>()
                .HasData(
                    new PersonEntity()
                    {
                        ID = JohnTravolta.ID,
                        FirstName = JohnTravolta.FirstName,
                        LastName = JohnTravolta.LastName,
                        BirthDate = JohnTravolta.BirthDate,
                        FotoUrl = JohnTravolta.FotoUrl
                    }, 
                    new PersonEntity()
                    {
                        ID = RandalKleiser.ID,
                        FirstName = RandalKleiser.FirstName,
                        LastName = RandalKleiser.LastName,
                        BirthDate = RandalKleiser.BirthDate,
                        FotoUrl = RandalKleiser.FotoUrl
                    }
                );
        }

        public static void SeedFilm(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmEntity>()
                .HasData(new FilmEntity()
                { 
                    ID = GreaseFilm.ID,
                    OriginalName = GreaseFilm.OriginalName,
                    CzechName = GreaseFilm.CzechName,
                    Genre = GreaseFilm.Genre,
                    TitleFotoUrl = GreaseFilm.TitleFotoUrl,
                    Country = GreaseFilm.Country,
                    Duration = GreaseFilm.Duration,
                    Description = GreaseFilm.Description
                });
        }

        public static void SeedReview(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewEntity>()
                .HasData(new ReviewEntity()
                {
                    ID = FilmReviews.ID,
                    NickName = FilmReviews.NickName,
                    Date = FilmReviews.Date,
                    Rating = FilmReviews.Rating,
                    TextReview = FilmReviews.TextReview,
                    FilmId = FilmReviews.FilmId
                });
        }
        public static void SeedActedInFilm(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActedInFilmEntity>()
                .HasData(new ActedInFilmEntity()
                {
                    ID = JohnTravoltaFilm.ID,
                    FilmId = JohnTravoltaFilm.FilmId,
                    ActorId = JohnTravoltaFilm.ActorId
                });
        }
        public static void SeedDirectedFilm(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DirectedFilmEntity>()
                .HasData(new DirectedFilmEntity()
                {
                    ID = RandalKleiserFilm.ID,
                    FilmId = RandalKleiserFilm.FilmId,
                    DirectorId = RandalKleiserFilm.DirectorId
                });
        }
    }
}