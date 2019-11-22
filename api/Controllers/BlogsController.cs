
using System;
using System.Collections.Generic;
using api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogsDbContext context;

        public BlogsController(BlogsDbContext context)
        {
            this.context = context;
            //TODO: Need better solution, e.g. creating DBs upfront with scripts
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return context.Blogs;
        }

        [HttpPost]
        public void CreatePost([ModelBinder]Blog blog)
        {
            context.Blogs.Add(blog);
            context.SaveChanges();
        }
    }
}