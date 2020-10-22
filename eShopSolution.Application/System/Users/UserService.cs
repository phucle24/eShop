using eShopSolution.Data.Configurations;
using eShopSolution.Utilities.Exeptions;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
                            RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return null;

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }
            var roles = _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Name, request.UserName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
              _config["Tokens:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<PageResult<UserVm>> GetUsersPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword)){
                query = query.Where(x => x.UserName.Contains(request.Keyword)
                || x.PhoneNumber.Contains(request.Keyword));
            }
            // 3.Paging
            int totalRow = await query.CountAsync();
            var data = await query
                .Select(x => new UserVm()
                {
                   Email = x.Email,
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   UserName = x.UserName,
                   PhoneNumber = x.PhoneNumber,
                   Id = x.Id
                }).ToListAsync();
            // 4.Select and projection
            var pagedReult = new PageResult<UserVm>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return pagedReult;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new AppUser()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Dob = request.Dob
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

    }
}
