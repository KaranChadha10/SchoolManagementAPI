using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
