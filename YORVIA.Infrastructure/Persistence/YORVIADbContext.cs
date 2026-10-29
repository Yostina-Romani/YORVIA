using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YORVIA.Domain.Entities;
using YORVIA.Infrastructure.Identity;

namespace YORVIA.Infrastructure.Persistence
{
    public class YORVIADbContext:IdentityDbContext<ApplicationUser>
    {
        public YORVIADbContext(DbContextOptions<YORVIADbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Course>().HasOne<ApplicationUser>().WithMany(user => user.courses)
                .HasForeignKey(courses => courses.userId).IsRequired();
        }

        
    public DbSet<Challenge> challenges { get; set; }

    public DbSet<Course> courses { get; set; }
    }
}
