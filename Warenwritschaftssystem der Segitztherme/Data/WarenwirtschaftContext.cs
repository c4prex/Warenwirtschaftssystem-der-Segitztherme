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
    }
}
