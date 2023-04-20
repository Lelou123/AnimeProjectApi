using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InitProject.Migrations
{
    /// <inheritdoc />
    public partial class AddEstudios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataFundacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnimeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudios_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnimeEstudio",
                columns: table => new
                {
                    EstudioId = table.Column<int>(type: "integer", nullable: false),
                    AnimeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeEstudio", x => new { x.AnimeId, x.EstudioId });
                    table.ForeignKey(
                        name: "FK_AnimeEstudio_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeEstudio_Estudios_EstudioId",
                        column: x => x.EstudioId,
                        principalTable: "Estudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeEstudio_EstudioId",
                table: "AnimeEstudio",
                column: "EstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudios_AnimeId",
                table: "Estudios",
                column: "AnimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeEstudio");

            migrationBuilder.DropTable(
                name: "Estudios");
        }
    }
}
