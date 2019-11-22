using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace api.Services
{
    public sealed class HeaderTenantIdentificationService : ITenantIdentificationService
    {
        private readonly TenantMapping _tenants;

        public HeaderTenantIdentificationService(IConfiguration configuration)
        {
            this._tenants = configuration.GetTenantMapping();
        }

        public HeaderTenantIdentificationService(TenantMapping tenants)
        {
            this._tenants = tenants;
        }

        public IEnumerable<string> GetAllTenants()
        {
            return this._tenants.Tenants.Values;
        }

        public string GetCurrentTenant(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("X-Tenant", out var headerValue))
            {
                if(_tenants.Tenants.TryGetValue(headerValue, out var tenant))
                {
                    return tenant;
                }
            }

            return _tenants.Default;
        }
    }
}