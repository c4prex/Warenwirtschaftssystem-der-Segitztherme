using Lagersystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Lagersystem.Models;
using Microsoft.AspNetCore.Identity;


namespace Lagersystem.Data
{
    public class WarenwirtschaftContext : IdentityDbContext<IdentityUser>
    {
        public WarenwirtschaftContext(DbContextOptions<WarenwirtschaftContext> options)
            : base(options)
        {
        }

        public DbSet<Lager> Lager { get; set; } = default!;
        public DbSet<HU> HUs { get; set; } = default!;
        public DbSet<Artikel> Artikels { get; set; } = default!;
        public DbSet<Lagerplatz> Lagerplaetze { get; set; } = default!;
    }
}
