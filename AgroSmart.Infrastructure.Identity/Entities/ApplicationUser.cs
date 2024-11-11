
using AgroSmart.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AgroSmart.Infraestructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }          
        public string ImageUser { get; set; }        
        public bool IsActive { get; set; }
    }
}

/*public List<Topic> Topics { get; set; }
        public List<Post> Posts { get; set; }*/