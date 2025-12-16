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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Foreign Key: Lagerplatz.LagerID -> Lager.LagerID
            modelBuilder.Entity<Lagerplatz>()
                .HasOne<Lager>()
                .WithMany()
                .HasForeignKey(lp => lp.LagerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Foreign Key: HU.ArtikelID -> Artikel.ArtikelID
            modelBuilder.Entity<HU>()
                .HasOne<Artikel>()
                .WithMany()
                .HasForeignKey(hu => hu.ArtikelID)
                .OnDelete(DeleteBehavior.Restrict);

            // Foreign Key: HU.LagerID -> Lager.LagerID
            modelBuilder.Entity<HU>()
                .HasOne<Lager>()
                .WithMany()
                .HasForeignKey(hu => hu.LagerID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

