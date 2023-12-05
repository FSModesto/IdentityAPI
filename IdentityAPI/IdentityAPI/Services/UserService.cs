using AutoMapper;
using IdentityAPI.Data.Dtos;
using IdentityAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task Create(CreateUserDto createUserDto)
        {
            User user = _mapper.Map<User>(createUserDto);

            IdentityResult result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
                throw new ApplicationException("User create failed!");
        }

        public async Task<string> Login(LoginUserDto loginUserDto)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, false, false);

            if (!result.Succeeded)
                throw new ApplicationException("Login failed!");

            var user = _signInManager.UserManager.Users.FirstOrDefault(wh => wh.NormalizedUserName == loginUserDto.UserName.ToUpper());

            string token = _tokenService.GenerateToken(user);

            return token;
        }
    }
}
