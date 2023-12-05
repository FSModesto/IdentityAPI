using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Model
{
    public class User : IdentityUser
    {
        public User() : base() { }

        public DateTime BirthDate { get; set; }
    }
}
