using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesManagememtSystem.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    publishTime = table.Column<int>(type: "int", nullable: false),
                    IsHit = table.Column<bool>(type: "bit", nullable: false),
                    ProduceDt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Maker",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maker", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Maker_Movie_MovieFK",
                        column: x => x.MovieFK,
                        principalTable: "Movie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieArtist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFamous = table.Column<bool>(type: "bit", nullable: false),
                    MovieFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieArtist", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieArtist_Movie_MovieFK",
                        column: x => x.MovieFK,
                        principalTable: "Movie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maker_MovieFK",
                table: "Maker",
                column: "MovieFK");

            migrationBuilder.CreateIndex(
                name: "IX_MovieArtist_MovieFK",
                table: "MovieArtist",
                column: "MovieFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maker");

            migrationBuilder.DropTable(
                name: "MovieArtist");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
