using Microsoft.EntityFrameworkCore;
using Warenwritschaftssystem_der_Segitztherme.Models;

namespace Warenwritschaftssystem_der_Segitztherme.Data
{
    public class WarenwirtschaftContext : DbContext
    {
        public WarenwirtschaftContext (DbContextOptions<WarenwirtschaftContext> options)
            : base(options)
        {
        }

        public DbSet<Lager> Lager { get; set; } = default!;
        public DbSet<HU> HUs { get; set; } = default!;
        public DbSet<Artikel> Artikels { get; set; } = default!;
        public DbSet<Lagerplatz> Lagerplaetze { get; set; } = default!;
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Foreign Keys für Lager
            modelBuilder.Entity<Lager>()
                .HasOne(l => l.ErstelltVonMitarbeiter)
                .WithMany()
                .HasForeignKey(l => l.ErstelltVon)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lager>()
                .HasOne(l => l.GeaendertVonMitarbeiter)
                .WithMany()
                .HasForeignKey(l => l.GeaendertVon)
                .OnDelete(DeleteBehavior.Restrict);

            // Foreign Key: Lagerplatz.LagerID -> Lager.LagerID
            modelBuilder.Entity<Lagerplatz>()
                .HasOne<Lager>()
                .WithMany()
                .HasForeignKey(lp => lp.LagerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lagerplatz>()
                .HasOne(lp => lp.ErstelltVonMitarbeiter)
                 .WithMany()
                 .HasForeignKey(lp => lp.ErstelltVon)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lagerplatz>()
                .HasOne(lp => lp.GeaendertVonMitarbeiter)
                .WithMany()
                .HasForeignKey(lp => lp.GeaendertVon)
                .OnDelete(DeleteBehavior.Restrict);

            // Foreign Keys für Artikel
            modelBuilder.Entity<Artikel>()
                .HasOne(a => a.ErstelltVonMitarbeiter)
                .WithMany()
                .HasForeignKey(a => a.ErstelltVon)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Artikel>()
                .HasOne(a => a.GeaendertVonMitarbeiter)
                .WithMany()
                .HasForeignKey(a => a.GeaendertVon)
                .OnDelete(DeleteBehavior.Restrict);

            // Foreign Key: HU.ArtikelID -> Artikel.ArtikelID
            modelBuilder.Entity<HU>()
                .HasOne<Artikel>()
                .WithMany()
                .HasForeignKey(hu => hu.ArtikelID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HU>()
                .HasOne(h => h.ErstelltVonMitarbeiter)
                .WithMany()
                .HasForeignKey(h => h.ErstelltVon)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HU>()
                .HasOne(h => h.GeaendertVonMitarbeiter)
                .WithMany()
                .HasForeignKey(h => h.GeaendertVon)
                .OnDelete(DeleteBehavior.Restrict);

            // Foreign Key: HU.LagerID -> Lager.LagerID
            modelBuilder.Entity<HU>()
                .HasOne<Lager>()
                .WithMany()
                .HasForeignKey(hu => hu.LagerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed-Daten: Test-Mitarbeiter
            modelBuilder.Entity<Mitarbeiter>().HasData(
                new Mitarbeiter
                {
                    MitarbeiterID = 1,
                    Vorname = "Frankich",
                    Nachname = "Schulz",
                    Email = "f.schulz@example.com",
                    Telefon = "0123456789",
                    IstAktiv = true,
                    ErstelltAm = DateTime.Now
                },
                new Mitarbeiter
                {
                    MitarbeiterID = 2,
                    Vorname = "System",
                    Nachname = "Admin",
                    Email = "admin@system.com",
                    IstAktiv = true,
                    ErstelltAm = DateTime.Now
                }
            );
        }
    }
}

