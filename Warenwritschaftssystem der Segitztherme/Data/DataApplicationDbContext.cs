using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warenwritschaftssystem_der_Segitztherme.Models;

namespace Warenwritschaftssystem_der_Segitztherme
{
    public class DataApplicationDbContext : DbContext
    {
        public DataApplicationDbContext (DbContextOptions<DataApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Warenwritschaftssystem_der_Segitztherme.Models.Lager> Lager { get; set; } = default!;
        public DbSet<Warenwritschaftssystem_der_Segitztherme.Models.HU> HU { get; set; } = default!;
        public DbSet<Warenwritschaftssystem_der_Segitztherme.Models.Artikel> Artikel { get; set; } = default!;
        public DbSet<Warenwritschaftssystem_der_Segitztherme.Models.Lagerplatz> Lagerplatz { get; set; } = default!;
    }
}
