using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Design;

namespace api.Model
{
    // used by tools, e.g. "dotnet ef migrations..."
    public class TenantsDbContextFactory : IDesignTimeDbContextFactory<TenantsDbContext>
    {
        public TenantsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TenantsDbContext>();
            optionsBuilder.UseNpgsql("database=tenants-db");

            return new TenantsDbContext(optionsBuilder.Options);
        }
    }

    public class TenantsDbContext : DbContext
    {
        private IConfiguration _config;

        public TenantsDbContext(DbContextOptions<TenantsDbContext> options) : base(options) { }

        public DbSet<Tenant> Tenants { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new NpgsqlModelTransformer().FixSnakeCaseNames(modelBuilder);
        }
    }
}