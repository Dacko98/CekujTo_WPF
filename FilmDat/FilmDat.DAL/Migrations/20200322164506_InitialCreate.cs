using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmDat.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    OriginalName = table.Column<string>(nullable: true),
                    CzechName = table.Column<string>(nullable: true),
                    Genre = table.Column<int>(nullable: false),
                    TitleFotoUrl = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Films", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FotoUrl = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Persons", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NickName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<long>(nullable: false),
                    TextReview = table.Column<string>(nullable: true),
                    FilmId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviews_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActedInFilmEntities",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FilmId = table.Column<Guid>(nullable: false),
                    ActorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActedInFilmEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActedInFilmEntities_Persons_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActedInFilmEntities_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectedFilmEntities",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FilmId = table.Column<Guid>(nullable: false),
                    DirectorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectedFilmEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DirectedFilmEntities_Persons_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectedFilmEntities_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[]
                    {"Id", "Country", "CzechName", "Description", "Duration", "Genre", "OriginalName", "TitleFotoUrl"},
                values: new object[]
                {
                    new Guid("088e40b8-63f6-4089-bfa9-4146e36e888c"), "USA", "Pomada", "Romanticky muzikal",
                    new TimeSpan(0, 2, 0, 0, 0), 7, "Grease", "pomada.jpg"
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] {"Id", "BirthDate", "FirstName", "FotoUrl", "LastName"},
                values: new object[]
                {
                    new Guid("e1e20085-1ce4-4612-be57-285b8c76d76a"),
                    new DateTime(1972, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "johntravolta.jpg",
                    "Travolta"
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] {"Id", "BirthDate", "FirstName", "FotoUrl", "LastName"},
                values: new object[]
                {
                    new Guid("6d372469-af50-4cfe-9582-8789bf598b2b"),
                    new DateTime(1972, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Randal", "randalklieser.jpg",
                    "Kleiser"
                });

            migrationBuilder.InsertData(
                table: "ActedInFilmEntities",
                columns: new[] {"Id", "ActorId", "FilmId"},
                values: new object[]
                {
                    new Guid("501744f2-4fc1-494b-8b84-5fecb9f7903d"), new Guid("e1e20085-1ce4-4612-be57-285b8c76d76a"),
                    new Guid("088e40b8-63f6-4089-bfa9-4146e36e888c")
                });

            migrationBuilder.InsertData(
                table: "DirectedFilmEntities",
                columns: new[] {"Id", "DirectorId", "FilmId"},
                values: new object[]
                {
                    new Guid("75cb065e-643a-4b6f-807f-b3add4cf0eca"), new Guid("6d372469-af50-4cfe-9582-8789bf598b2b"),
                    new Guid("088e40b8-63f6-4089-bfa9-4146e36e888c")
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] {"Id", "Date", "FilmId", "NickName", "Rating", "TextReview"},
                values: new object[]
                {
                    new Guid("585b8ad0-aa06-49dd-94fd-8ab6c93f7e57"),
                    new DateTime(2013, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new Guid("088e40b8-63f6-4089-bfa9-4146e36e888c"), "Alan232", 82L, "Skvely film plny tanca a zabavy"
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActedInFilmEntities_ActorId",
                table: "ActedInFilmEntities",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActedInFilmEntities_FilmId_ActorId",
                table: "ActedInFilmEntities",
                columns: new[] {"FilmId", "ActorId"},
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DirectedFilmEntities_DirectorId",
                table: "DirectedFilmEntities",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectedFilmEntities_FilmId_DirectorId",
                table: "DirectedFilmEntities",
                columns: new[] {"FilmId", "DirectorId"},
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FilmId",
                table: "Reviews",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActedInFilmEntities");

            migrationBuilder.DropTable(
                name: "DirectedFilmEntities");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}