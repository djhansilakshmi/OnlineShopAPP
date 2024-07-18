using Microsoft.AspNetCore.Identity;

namespace OnlineShopAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
