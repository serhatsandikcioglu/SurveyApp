using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using SurveyApp.Service.Interfaces;
using SurveyApp.UI.Models;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IValidator<RegisterDTO> _validator;

        public AccountController(IValidator<RegisterDTO> validator, IAuthService authService)
        {
            _validator = validator;
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                bool isAuthenticated = await _authService.AuthenticateAsync(model.EMail, model.Password);
                if (isAuthenticated)
                {
                    return Redirect("/");
                }
                ModelState.AddModelError("Error", "Invalid username or password");
            }
            return View();
        }
        public async Task<IActionResult> Logout([FromQuery(Name ="ReturnUrl")]string returnUrl="/")
        {
            await _authService.LogoutAsync();
            return Redirect(returnUrl);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerDTO)
        {
            var validationResult = _validator.Validate(registerDTO);
            if (validationResult.IsValid)
            {

            bool isSuccess = await _authService.RegisterUserAsync(registerDTO);
                if (isSuccess)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Email is already taken");
                }
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
 }
