using CaveProvider.Core.Model;
using CaveProvider.Database.Context.Interface;
using Microsoft.EntityFrameworkCore;

namespace CaveProvider.Database.Context
{
    public class PostgresDbContext: ApplicationDbContext, IPostgresDbContext
    {
        public PostgresDbContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection"));
        }
    }
}
