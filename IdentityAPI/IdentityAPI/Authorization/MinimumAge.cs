using Microsoft.AspNetCore.Authorization;

namespace IdentityAPI.Authorization
{
    public class MinimumAge : IAuthorizationRequirement
    {
        public MinimumAge(int age)
        {
            Age = age;
        }

        public int Age { get; set; }
    }
}
