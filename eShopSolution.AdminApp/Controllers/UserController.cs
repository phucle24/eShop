 using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using eShopSolution.AdminApp.Services;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace eShopSolution.AdminApp.Controllers
{   
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;

        public UserController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }


        /// <summary>
        /// Home Index
        /// </summary>
        /// <param name="Keyword"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string Keyword, int pageIndex = 1, int pageSize = 10)
        {
            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetUserPagingRequest()
            {
                Keyword = Keyword,
                PageIndex = pageIndex,
                PageSize = pageSize

            };
            var data = await _userApiClient.GetUsersPaging(request);
            //var user = User.Identity.Name;
            return View(data.ResultObj);
        }

       
        /// <summary>
        /// Get View Create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create User Controler
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.RegisterUser(request);

           if(result.IsSuccessed)
                return RedirectToAction("Index");
            ModelState.AddModelError("", result.Message);
            return View(request);
        } 
        
        
        /// <summary>
        /// Get View User by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _userApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updateRequest = new UserUpdateRequest()
                {
                    DoB = user.DoB,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Id = id
                };
                return View(updateRequest);
            }

            return RedirectToAction("Error", "Home");
        }

        /// <summary>
        /// Update User Controler
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var result = await _userApiClient.UpdateUser(request.Id, request);

            if(result.IsSuccessed)
                return RedirectToAction("Index");
            ModelState.AddModelError("", result.Message);
            return View(request);
        }


        /// <summary>
        /// Logout User Controler
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Home");
        }

      
    }
}