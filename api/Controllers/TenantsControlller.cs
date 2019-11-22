using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Model;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly TenantsDbContext context;

        public TenantsController(TenantsDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Tenant> Get()
        {
            context.Database.EnsureCreated();
            return context.Tenants;
        }

        [HttpPost]
        public void CreatePost([ModelBinder]Tenant tenant)
        {
            context.Database.EnsureCreated();
            context.Tenants.Add(tenant);
            context.SaveChanges();
        }
    }
}