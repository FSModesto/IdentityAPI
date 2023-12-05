using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace IdentityAPI.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimumAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
        {
            var birthDateClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (birthDateClaim is null)
                return Task.CompletedTask;

            DateTime birthDate = Convert.ToDateTime(birthDateClaim.Value);

            var userAge = DateTime.Today.Year - birthDate.Year;

            if (birthDate > DateTime.Today.AddYears(-1))
                userAge--;

            if (userAge >= requirement.Age)
                context.Succeed(requirement);

            return Task.CompletedTask;

        }
    }
}
