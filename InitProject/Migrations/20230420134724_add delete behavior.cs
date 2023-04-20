using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitProject.Migrations
{
    /// <inheritdoc />
    public partial class adddeletebehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Animes_AnimeId",
                table: "Episodes");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Animes_AnimeId",
                table: "Episodes",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Animes_AnimeId",
                table: "Episodes");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Animes_AnimeId",
                table: "Episodes",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
