using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InitProject.Migrations;

/// <inheritdoc />
public partial class pgTeste : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Animes",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Titulo = table.Column<string>(type: "text", nullable: false),
                Genero = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                AnoLancamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Animes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Episodes",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Titulo = table.Column<string>(type: "text", nullable: false),
                Numero = table.Column<int>(type: "integer", nullable: false),
                Duracao = table.Column<int>(type: "integer", nullable: false),
                AnimeId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Episodes", x => x.Id);
                table.ForeignKey(
                    name: "FK_Episodes_Animes_AnimeId",
                    column: x => x.AnimeId,
                    principalTable: "Animes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Episodes_AnimeId",
            table: "Episodes",
            column: "AnimeId",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Episodes");

        migrationBuilder.DropTable(
            name: "Animes");
    }
}
