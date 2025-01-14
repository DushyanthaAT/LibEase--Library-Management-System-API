using Microsoft.AspNetCore.Identity;

namespace LibEaseAPI.Models.Entities
{
    public class User : IdentityUser
    {
        public Guid UserId { get; set; }
    }
}
