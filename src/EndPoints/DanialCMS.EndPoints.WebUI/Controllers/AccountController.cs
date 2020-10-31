using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanialCMS.EndPoints.WebUI.Models.Account;
using DanialCMS.EndPoints.WebUI.Infrastructures.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DanialCMS.Core.Domain.Emails.Entities;
using DanialCMS.Core.Domain.Emails.Services;

namespace DanialCMS.EndPoints.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPasswordValidator<User> _passwordValidator;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IPasswordValidator<User> passwordValidator,
            IPasswordHasher<User> passwordHasher,
            IEmailService emailService,
            IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._passwordValidator = passwordValidator;
            this._passwordHasher = passwordHasher;
            this._emailService = emailService;
            this._configuration = configuration;
        }

        [AllowAnonymous]
        public IActionResult LogIn(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new LogInViewModel()
                {
                    ReturnUrl = returnUrl
                });
            }
            return RedirectToAction("Index", "Home");    
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    User user;
                    if (model.EmailOrUsername.Contains("@"))
                    {
                        user = await _userManager.FindByEmailAsync(model.EmailOrUsername);
                    }
                    else
                    {
                        user = await _userManager.FindByNameAsync(model.EmailOrUsername);
                    }
                    if (user != null)
                    {
                        await _signInManager.SignOutAsync();
                        var tryCount = user.AccessFailedCount;
                        var lockOut = tryCount >= 5;
                        var result = await _signInManager.PasswordSignInAsync(
                            user, model.Password, false, lockOut);
                        if (result.Succeeded)
                        {
                            return Redirect(model.ReturnUrl ?? "/");
                        }
                    }
                    ModelState.AddModelError("",
                            "نام کاربری یا کلمه عبور اشتباه است");

                }
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied() => View();

        [AllowAnonymous]
        public IActionResult ForgetPassword() 
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(); 
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callback = Url.Action(nameof(ResetPassword), "Account", 
                        new { token, email = user.Email }, Request.Scheme);
                    var message = new Message()
                    {
                        FromAddresses = new List<EmailAddress>()
                        { new EmailAddress() { Address =
                            _configuration.GetSection("EmailConfiguration").GetValue<string>("CMSEmail")} },
                        ToAddresses = new List<EmailAddress>()
                        { new EmailAddress() { Address = model.Email } },
                        Subject = "ریست پسورد",
                        Content = string.Format("{0} عزیز لینک ریست پسورد شما:\n {1}", 
                        user.UserName, callback)
                    };
                    _emailService.Send(message);
                    return View(nameof(ForgotPasswordConfirmation));
                }
                else
                {
                    ModelState.AddModelError("", "این ایمیل وجود ندارد");
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(token))
            {
                return View(nameof(NotFound));
            }

            return View(new ResetPasswordViewModel() 
            { Token = token, Email = email });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    IdentityResult validPass = null;
                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        if (model.Password == model.RePassword)
                        {
                            validPass = await _passwordValidator.ValidateAsync(
                            _userManager, user, model.Password);
                            if (validPass.Succeeded)
                            {
                                user.PasswordHash = _passwordHasher.HashPassword(
                                    user, model.Password);
                            }
                            else
                            {
                                AddErrosFromResult(validPass);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", 
                                "تکرار کلمه عبور را اشتباه وارد کردید");
                        }
                    }

                    if (validPass != null && validPass.Succeeded)
                    {
                        var result = await _userManager.ResetPasswordAsync(user, 
                            model.Token, model.Password);
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(LogIn));
                        }
                        else
                        {
                            AddErrosFromResult(result);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "کاربر یافت نشد");
                }
            }
            return View(model);           
        }




        private void AddErrosFromResult(IdentityResult result)
        {
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError(err.Code, err.Description);
            }
        }

    }
}
