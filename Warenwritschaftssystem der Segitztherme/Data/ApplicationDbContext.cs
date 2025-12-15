using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Warenwritschaftssystem_der_Segitztherme.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
    

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
