using System.Collections.Generic;
using System.Linq;
using api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace api.Services
{
    public sealed class DbTenantIdentificationService : ITenantIdentificationService
    {
        private readonly TenantMapping _tenants;

        public DbTenantIdentificationService(TenantsDbContext context)
        {
            _tenants = new TenantMapping(){
                Default = "undefined"
            };
            foreach(var t in context.Tenants)
            {
                _tenants.Tenants.Add(t.Key, t.Key);
            }
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