using api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace api.Model
{
    // used by tools, e.g. "dotnet ef migrations..."
    public class BlogsDbContextFactory : IDesignTimeDbContextFactory<BlogsDbContext>
    {
        public BlogsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogsDbContext>();
            optionsBuilder.UseNpgsql("database=undefined-db");

            return new BlogsDbContext(optionsBuilder.Options);
        }
    }

    public class BlogsDbContext : DbContext
    {
        private readonly ITenantService tenantService;
        private readonly IConfiguration configuration;

        public BlogsDbContext(DbContextOptions<BlogsDbContext> options) : base(options) { }
        public BlogsDbContext(ITenantService tenantService, IConfiguration configuration)
        {
            this.tenantService = tenantService;
            this.configuration = configuration;
        }

        public DbSet<Blog> Blogs { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenant = tenantService?.GetCurrentTenant() ?? "undefined";

            var templateConnectionString = configuration.GetConnectionString("blogs-db") ??
                "Host=192.168.99.100;Database={tenant}-db;Username=pguser;Password=topsecret";
            var tenantConnectionString = templateConnectionString.Replace("{tenant}", tenant);

            optionsBuilder.UseNpgsql(tenantConnectionString);
    
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new NpgsqlModelTransformer().FixSnakeCaseNames(modelBuilder);
        }
    }
}