using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warenwritschaftssystem_der_Segitztherme.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithMitarbeiter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mitarbeiter",
                columns: table => new
                {
                    MitarbeiterID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vorname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nachname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    IstAktiv = table.Column<bool>(type: "INTEGER", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitarbeiter", x => x.MitarbeiterID);
                });

            migrationBuilder.CreateTable(
                name: "Artikels",
                columns: table => new
                {
                    ArtikelID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtikelName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ArtikelBeschreibung = table.Column<string>(type: "TEXT", nullable: false),
                    ArtikelGewicht = table.Column<float>(type: "REAL", nullable: false),
                    ArtikelMaße = table.Column<float>(type: "REAL", nullable: false),
                    ErstelltVon = table.Column<int>(type: "INTEGER", nullable: true),
                    ErstelltAm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GeaendertVon = table.Column<int>(type: "INTEGER", nullable: true),
                    GeaendertAm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikels", x => x.ArtikelID);
                    table.ForeignKey(
                        name: "FK_Artikels_Mitarbeiter_ErstelltVon",
                        column: x => x.ErstelltVon,
                        principalTable: "Mitarbeiter",
                        principalColumn: "MitarbeiterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artikels_Mitarbeiter_GeaendertVon",
                        column: x => x.GeaendertVon,
                        principalTable: "Mitarbeiter",
                        principalColumn: "MitarbeiterID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lager",
                columns: table => new
                {
                    LagerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Beschreibung = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ErstelltVon = table.Column<int>(type: "INTEGER", nullable: true),
                    ErstelltAm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GeaendertVon = table.Column<int>(type: "INTEGER", nullable: true),
                    GeaendertAm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lager", x => x.LagerID);
                    table.ForeignKey(
                        name: "FK_Lager_Mitarbeiter_ErstelltVon",
                        column: x => x.ErstelltVon,
                        principalTable: "Mitarbeiter",
                        principalColumn: "MitarbeiterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lager_Mitarbeiter_GeaendertVon",
                        column: x => x.GeaendertVon,
                        principalTable: "Mitarbeiter",
                        principalColumn: "MitarbeiterID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HUs",
                columns: table => new
                {
                    HuId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtikelID = table.Column<int>(type: "INTEGER", nullable: false),
                    LagerID = table.Column<int>(type: "INTEGER", nullable: false),
                    GewichtHu = table.Column<float>(type: "REAL", nullable: false),
                    AnzahlArtikel = table.Column<int>(type: "INTEGER", nullable: false),
                    ErstelltVon = table.Column<int>(type: "INTEGER", nullable: true),
                    ErstelltAm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GeaendertVon = table.Column<int>(type: "INTEGER", nullable: true),
                    GeaendertAm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HUs", x => x.HuId);
                    table.ForeignKey(
                        name: "FK_HUs_Artikels_ArtikelID",
                        column: x => x.ArtikelID,
                        principalTable: "Artikels",
                        principalColumn: "ArtikelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HUs_Lager_LagerID",
                        column: x => x.LagerID,
                        principalTable: "Lager",
                        principalColumn: "LagerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HUs_Mitarbeiter_ErstelltVon",
                        column: x => x.ErstelltVon,
                        principalTable: "Mitarbeiter",
                        principalColumn: "MitarbeiterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HUs_Mitarbeiter_GeaendertVon",
                        column: x => x.GeaendertVon,
                        principalTable: "Mitarbeiter",
                        principalColumn: "MitarbeiterID",
                        onDelete: ReferentialAction.Restrict);
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
                    LagerTyp = table.Column<string>(type: "TEXT", nullable: false),
                    ErstelltVon = table.Column<int>(type: "INTEGER", nullable: true),
                    ErstelltAm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GeaendertVon = table.Column<int>(type: "INTEGER", nullable: true),
                    GeaendertAm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagerplaetze", x => x.LagerPlatzID);
                    table.ForeignKey(
                        name: "FK_Lagerplaetze_Lager_LagerID",
                        column: x => x.LagerID,
                        principalTable: "Lager",
                        principalColumn: "LagerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lagerplaetze_Mitarbeiter_ErstelltVon",
                        column: x => x.ErstelltVon,
                        principalTable: "Mitarbeiter",
                        principalColumn: "MitarbeiterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lagerplaetze_Mitarbeiter_GeaendertVon",
                        column: x => x.GeaendertVon,
                        principalTable: "Mitarbeiter",
                        principalColumn: "MitarbeiterID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Mitarbeiter",
                columns: new[] { "MitarbeiterID", "Email", "ErstelltAm", "IstAktiv", "Nachname", "Telefon", "Vorname" },
                values: new object[,]
                {
                    { 1, "f.schulz@example.com", new DateTime(2025, 12, 18, 9, 25, 30, 490, DateTimeKind.Local).AddTicks(8332), true, "Schulz", "0123456789", "Frankich" },
                    { 2, "admin@system.com", new DateTime(2025, 12, 18, 9, 25, 30, 490, DateTimeKind.Local).AddTicks(8337), true, "Admin", null, "System" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikels_ErstelltVon",
                table: "Artikels",
                column: "ErstelltVon");

            migrationBuilder.CreateIndex(
                name: "IX_Artikels_GeaendertVon",
                table: "Artikels",
                column: "GeaendertVon");

            migrationBuilder.CreateIndex(
                name: "IX_HUs_ArtikelID",
                table: "HUs",
                column: "ArtikelID");

            migrationBuilder.CreateIndex(
                name: "IX_HUs_ErstelltVon",
                table: "HUs",
                column: "ErstelltVon");

            migrationBuilder.CreateIndex(
                name: "IX_HUs_GeaendertVon",
                table: "HUs",
                column: "GeaendertVon");

            migrationBuilder.CreateIndex(
                name: "IX_HUs_LagerID",
                table: "HUs",
                column: "LagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Lager_ErstelltVon",
                table: "Lager",
                column: "ErstelltVon");

            migrationBuilder.CreateIndex(
                name: "IX_Lager_GeaendertVon",
                table: "Lager",
                column: "GeaendertVon");

            migrationBuilder.CreateIndex(
                name: "IX_Lagerplaetze_ErstelltVon",
                table: "Lagerplaetze",
                column: "ErstelltVon");

            migrationBuilder.CreateIndex(
                name: "IX_Lagerplaetze_GeaendertVon",
                table: "Lagerplaetze",
                column: "GeaendertVon");

            migrationBuilder.CreateIndex(
                name: "IX_Lagerplaetze_LagerID",
                table: "Lagerplaetze",
                column: "LagerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HUs");

            migrationBuilder.DropTable(
                name: "Lagerplaetze");

            migrationBuilder.DropTable(
                name: "Artikels");

            migrationBuilder.DropTable(
                name: "Lager");

            migrationBuilder.DropTable(
                name: "Mitarbeiter");
        }
    }
}
