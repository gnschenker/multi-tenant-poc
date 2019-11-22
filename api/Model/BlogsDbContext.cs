using System;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace api.Model
{
    public class BlogsDbContext : DbContext
    {
        private readonly ITenantService tenantService;
        private readonly IConfiguration configuration;

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