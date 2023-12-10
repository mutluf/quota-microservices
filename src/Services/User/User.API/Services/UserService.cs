using AutoMapper;
using Microsoft.AspNetCore.Identity;
using User.API.Dtos;

namespace User.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Entities.User> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<Entities.User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> RegisterUserAsync(RegisterDto userData)
        {
            var user = _mapper.Map<Entities.User>(userData);    
            var result = await _userManager.CreateAsync(user, userData.Password);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}
