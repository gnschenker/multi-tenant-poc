using System;

namespace api.Model
{
    public class Tenant
    {
        public Tenant()
        {
            CreatedOn = DateTime.Now;
        }
        
        public string Id { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; } 
    }
}