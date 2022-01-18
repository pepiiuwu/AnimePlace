using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimePlace.Data.Migrations
{
    public partial class addedStudios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeStudio",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "int", nullable: false),
                    StudiosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStudio", x => new { x.AnimesId, x.StudiosId });
                    table.ForeignKey(
                        name: "FK_AnimeStudio_Animes_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeStudio_Studio_StudiosId",
                        column: x => x.StudiosId,
                        principalTable: "Studio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeStudio_StudiosId",
                table: "AnimeStudio",
                column: "StudiosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeStudio");

            migrationBuilder.DropTable(
                name: "Studio");
        }
    }
}
