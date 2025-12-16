using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warenwritschaftssystem_der_Segitztherme.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Lagerplaetze_LagerID",
                table: "Lagerplaetze",
                column: "LagerID");

            migrationBuilder.CreateIndex(
                name: "IX_HUs_ArtikelID",
                table: "HUs",
                column: "ArtikelID");

            migrationBuilder.CreateIndex(
                name: "IX_HUs_LagerID",
                table: "HUs",
                column: "LagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_HUs_Artikels_ArtikelID",
                table: "HUs",
                column: "ArtikelID",
                principalTable: "Artikels",
                principalColumn: "ArtikelID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HUs_Lager_LagerID",
                table: "HUs",
                column: "LagerID",
                principalTable: "Lager",
                principalColumn: "LagerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lagerplaetze_Lager_LagerID",
                table: "Lagerplaetze",
                column: "LagerID",
                principalTable: "Lager",
                principalColumn: "LagerID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HUs_Artikels_ArtikelID",
                table: "HUs");

            migrationBuilder.DropForeignKey(
                name: "FK_HUs_Lager_LagerID",
                table: "HUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Lagerplaetze_Lager_LagerID",
                table: "Lagerplaetze");

            migrationBuilder.DropIndex(
                name: "IX_Lagerplaetze_LagerID",
                table: "Lagerplaetze");

            migrationBuilder.DropIndex(
                name: "IX_HUs_ArtikelID",
                table: "HUs");

            migrationBuilder.DropIndex(
                name: "IX_HUs_LagerID",
                table: "HUs");
        }
    }
}
