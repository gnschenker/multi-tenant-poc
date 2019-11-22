using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Model
{
    public class TenantsDbContext : DbContext
    {
        public TenantsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Tenant> Tenants { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new NpgsqlModelTransformer().FixSnakeCaseNames(modelBuilder);
        }
    }
}