using Microsoft.Extensions.Configuration;

namespace api.Services
{
    public static class ConfigurationExtensions
    {
        public static TenantMapping GetTenantMapping(this IConfiguration configuration)
        {
            return configuration.GetSection("Tenants").Get<TenantMapping>();
        }
    }
}