using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace api.Services
{
    public sealed class HostTenantIdentificationService : ITenantIdentificationService
    {
        private readonly TenantMapping _tenants;

        public HostTenantIdentificationService(IConfiguration configuration)
        {
            this._tenants = configuration.GetTenantMapping();
        }

        public HostTenantIdentificationService(TenantMapping tenants)
        {
            this._tenants = tenants;
        }

        public IEnumerable<string> GetAllTenants()
        {
            return this._tenants.Tenants.Values;
        }

        public string GetCurrentTenant(HttpContext context)
        {
            var host = context.Request.Host.Host;
            if (!this._tenants.Tenants.TryGetValue(host, out var tenant))
            {
                tenant = this._tenants.Default;
            }

            return tenant;
        }
    }
}