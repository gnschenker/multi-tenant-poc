using Microsoft.AspNetCore.Http;

namespace api.Services
{
    public interface ITenantIdentificationService
    {
        string GetCurrentTenant(HttpContext context);
    }
}