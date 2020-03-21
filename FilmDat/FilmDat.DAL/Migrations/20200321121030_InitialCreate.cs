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
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.ID);
                });

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
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });

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
                        principalColumn: "ID",
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActedInFilmEntities_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "ID",
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectedFilmEntities_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActedInFilmEntities_ActorId",
                table: "ActedInFilmEntities",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActedInFilmEntities_FilmId",
                table: "ActedInFilmEntities",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectedFilmEntities_DirectorId",
                table: "DirectedFilmEntities",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectedFilmEntities_FilmId",
                table: "DirectedFilmEntities",
                column: "FilmId");

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
