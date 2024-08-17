using CaveProvider.Identity.API.Database.Context.Interface;
using Microsoft.EntityFrameworkCore;

namespace CaveProvider.Identity.API.Database.Context
{
    public class SqlServerDbContext : ApplicationDbContext, ISqlServerDbContext
    {
        public SqlServerDbContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
