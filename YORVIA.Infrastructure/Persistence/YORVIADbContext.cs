using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using YORVIA.Domain.Entities;
using YORVIA.Infrastructure.Identity;

namespace YORVIA.Infrastructure.Persistence
{
    public class YORVIADbContext:IdentityDbContext<ApplicationUser>
    {
        public YORVIADbContext(DbContextOptions<YORVIADbContext> options):base(options)
        {

        }
    public DbSet<Challenge> challenges { get; set; }
    }
}
