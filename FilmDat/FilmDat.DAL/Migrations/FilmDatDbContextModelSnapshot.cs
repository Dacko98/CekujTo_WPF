﻿// <auto-generated />
using System;
using FilmDat.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilmDat.DAL.Migrations
{
    [DbContext(typeof(FilmDatDbContext))]
    partial class FilmDatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FilmDat.DAL.Entities.ActedInFilmEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("FilmId", "ActorId")
                        .IsUnique();

                    b.ToTable("ActedInFilms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("501744f2-4fc1-494b-8b84-5fecb9f7903d"),
                            ActorId = new Guid("e1e20085-1ce4-4612-be57-285b8c76d76a"),
                            FilmId = new Guid("088e40b8-63f6-4089-bfa9-4146e36e888c")
                        },
                        new
                        {
                            Id = new Guid("a81ae9bd-3a1d-4612-b27e-a6a3d5cbaf9b"),
                            ActorId = new Guid("0a816848-99a5-4aae-8449-487d0847998a"),
                            FilmId = new Guid("16d3e5e1-a52a-4fbc-ac16-305491fe0b8e")
                        });
                });

            modelBuilder.Entity("FilmDat.DAL.Entities.DirectedFilmEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DirectorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("FilmId", "DirectorId")
                        .IsUnique();

                    b.ToTable("DirectedFilms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("75cb065e-643a-4b6f-807f-b3add4cf0eca"),
                            DirectorId = new Guid("6d372469-af50-4cfe-9582-8789bf598b2b"),
                            FilmId = new Guid("088e40b8-63f6-4089-bfa9-4146e36e888c")
                        },
                        new
                        {
                            Id = new Guid("5a4d3189-5daa-420e-9360-1146505a3d4d"),
                            DirectorId = new Guid("0ae10491-658f-4fa8-860b-215ebb29cba2"),
                            FilmId = new Guid("16d3e5e1-a52a-4fbc-ac16-305491fe0b8e")
                        });
                });

            modelBuilder.Entity("FilmDat.DAL.Entities.FilmEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CzechName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("OriginalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleFotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = new Guid("088e40b8-63f6-4089-bfa9-4146e36e888c"),
                            Country = "USA",
                            CzechName = "Pomada",
                            Description = "Romanticky muzikal",
                            Duration = new TimeSpan(0, 2, 0, 0, 0),
                            Genre = 7,
                            OriginalName = "Grease",
                            TitleFotoUrl = "pomada.jpg"
                        },
                        new
                        {
                            Id = new Guid("16d3e5e1-a52a-4fbc-ac16-305491fe0b8e"),
                            Country = "USA",
                            CzechName = "Intergalakticky",
                            Description = "Scifi mindfuck...",
                            Duration = new TimeSpan(0, 2, 0, 0, 0),
                            Genre = 8,
                            OriginalName = "Interstellar",
                            TitleFotoUrl = "gargantua.jpg"
                        });
                });

            modelBuilder.Entity("FilmDat.DAL.Entities.PersonEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e1e20085-1ce4-4612-be57-285b8c76d76a"),
                            BirthDate = new DateTime(1972, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            FotoUrl = "johntravolta.jpg",
                            LastName = "Travolta"
                        },
                        new
                        {
                            Id = new Guid("6d372469-af50-4cfe-9582-8789bf598b2b"),
                            BirthDate = new DateTime(1972, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Randal",
                            FotoUrl = "randalkleiser.jpg",
                            LastName = "Kleiser"
                        },
                        new
                        {
                            Id = new Guid("0a816848-99a5-4aae-8449-487d0847998a"),
                            BirthDate = new DateTime(1979, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Matthew",
                            FotoUrl = "mato.jpg",
                            LastName = "McConaughey"
                        },
                        new
                        {
                            Id = new Guid("0ae10491-658f-4fa8-860b-215ebb29cba2"),
                            BirthDate = new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Christopher",
                            FotoUrl = "chris.jpg",
                            LastName = "Nolan"
                        });
                });

            modelBuilder.Entity("FilmDat.DAL.Entities.ReviewEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Rating")
                        .HasColumnType("bigint");

                    b.Property<string>("TextReview")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("585b8ad0-aa06-49dd-94fd-8ab6c93f7e57"),
                            Date = new DateTime(2013, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FilmId = new Guid("088e40b8-63f6-4089-bfa9-4146e36e888c"),
                            NickName = "Alan232",
                            Rating = 82L,
                            TextReview = "Skvely film plny tanca a zabavy."
                        });
                });

            modelBuilder.Entity("FilmDat.DAL.Entities.ActedInFilmEntity", b =>
                {
                    b.HasOne("FilmDat.DAL.Entities.PersonEntity", "Actor")
                        .WithMany("ActedInFilms")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmDat.DAL.Entities.FilmEntity", "Film")
                        .WithMany("Actors")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmDat.DAL.Entities.DirectedFilmEntity", b =>
                {
                    b.HasOne("FilmDat.DAL.Entities.PersonEntity", "Director")
                        .WithMany("DirectedFilms")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmDat.DAL.Entities.FilmEntity", "Film")
                        .WithMany("Directors")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmDat.DAL.Entities.ReviewEntity", b =>
                {
                    b.HasOne("FilmDat.DAL.Entities.FilmEntity", "Film")
                        .WithMany("Reviews")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
