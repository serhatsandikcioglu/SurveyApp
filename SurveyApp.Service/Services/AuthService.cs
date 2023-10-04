using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using SurveyApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthService(UserManager<AspNetUser> userManager, IMapper mapper, SignInManager<AspNetUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            AspNetUser user = await _userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                await _signInManager.SignOutAsync();
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                return result.Succeeded;
            }
            return false;
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<bool> RegisterUserAsync(RegisterDTO registerDTO)
        {
            AspNetUser aspNetUser = _mapper.Map<AspNetUser>(registerDTO);
            aspNetUser.UserName = registerDTO.EMail;

            var result = await _userManager.CreateAsync(aspNetUser, registerDTO.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(aspNetUser, "User");

                if (roleResult.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
