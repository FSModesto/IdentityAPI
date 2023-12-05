using AutoMapper;
using IdentityAPI.Data.Dtos;
using IdentityAPI.Model;

namespace IdentityAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
