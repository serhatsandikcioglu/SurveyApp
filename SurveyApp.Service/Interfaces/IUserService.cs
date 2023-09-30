using Microsoft.AspNetCore.Identity;
using SurveyApp.Data.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task LogoutAsync();
        Task<bool> RegisterUserAsync(RegisterDTO registerDTO);
    }
}
