using CaveProvider.Identity.API.Database.Context.Interface;
using CaveProvider.Identity.API.Database.Seed;
using CaveProvider.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CaveProvider.Identity.API.Database.Context
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser,
                                                          ApplicationRole,
                                                          string, IdentityUserClaim<string>,
                                                          ApplicationUserRole,
                                                          IdentityUserLogin<string>,
                                                          IdentityRoleClaim<string>,
                                                          IdentityUserToken<string>>, IApplicationDbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { }
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<ApplicationUser>(entity => entity.ToTable(name: "Users"));
            builder.Entity<ApplicationRole>(entity => entity.ToTable(name: "Roles"));
            builder.Entity<ApplicationUserRole>(entity => entity.ToTable("UserRoles"));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable("UserClaims"));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable("UserLogins"));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable("RoleClaims"));
            builder.Entity<IdentityUserToken<string>>(entity => entity.ToTable("UserTokens"));

            builder.SeedRoles();
        }
    }
}
