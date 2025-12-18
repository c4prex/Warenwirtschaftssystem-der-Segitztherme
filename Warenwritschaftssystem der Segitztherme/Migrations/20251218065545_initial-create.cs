using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warenwritschaftssystem_der_Segitztherme.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HUs",
                columns: table => new
                {
                    HuId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtikelID = table.Column<int>(type: "INTEGER", nullable: false),
                    LagerID = table.Column<int>(type: "INTEGER", nullable: false),
                    GewichtHu = table.Column<float>(type: "REAL", nullable: false),
                    AnzahlArtikel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HUs", x => x.HuId);
                });

            migrationBuilder.CreateTable(
                name: "Lager",
                columns: table => new
                {
                    LagerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Beschreibung = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lager", x => x.LagerID);
                });

            migrationBuilder.CreateTable(
                name: "Lagerplaetze",
                columns: table => new
                {
                    LagerPlatzID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LagerPlatzName = table.Column<string>(type: "TEXT", nullable: false),
                    LagerID = table.Column<int>(type: "INTEGER", nullable: false),
                    HUAnzahl = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxGewicht = table.Column<float>(type: "REAL", nullable: false),
                    LagerBereich = table.Column<string>(type: "TEXT", nullable: false),
                    LagerTyp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagerplaetze", x => x.LagerPlatzID);
                });

            migrationBuilder.CreateTable(
                name: "Artikels",
                columns: table => new
                {
                    ArtikelID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtikelName = table.Column<string>(type: "TEXT", nullable: false),
                    ArtikelBeschreibung = table.Column<string>(type: "TEXT", nullable: true),
                    ArtikelGewicht = table.Column<float>(type: "REAL", nullable: false),
                    ArtikelMaße = table.Column<float>(type: "REAL", nullable: false),
                    Bestand = table.Column<int>(type: "INTEGER", nullable: false),
                    Mindestbestand = table.Column<int>(type: "INTEGER", nullable: false),
                    LagerID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikels", x => x.ArtikelID);
                    table.ForeignKey(
                        name: "FK_Artikels_Lager_LagerID",
                        column: x => x.LagerID,
                        principalTable: "Lager",
                        principalColumn: "LagerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikels_LagerID",
                table: "Artikels",
                column: "LagerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artikels");

            migrationBuilder.DropTable(
                name: "HUs");

            migrationBuilder.DropTable(
                name: "Lagerplaetze");

            migrationBuilder.DropTable(
                name: "Lager");
        }
    }
}
