using DanialCMS.EndPoints.WebUI.Infrastructures.Identity;
using DanialCMS.EndPoints.WebUI.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;


namespace DanialCMS.EndPoints.WebUI.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> _userManager;
        private readonly IUserValidator<User> _userValidator;
        private readonly IPasswordValidator<User> _passwordValidator;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager,
            IUserValidator<User> userValidator,
            IPasswordValidator<User> passwordValidator,
            IPasswordHasher<User> passwordHasher,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userValidator = userValidator;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
            _roleManager = roleManager;
        }


        public IActionResult Index() => View(nameof(List), 
            _userManager.Users.ToList());

        public IActionResult List(List<string> errors = null)
        {
            AddErrosToModelState(errors);
            var users = _userManager.Users.ToList();
            if(!users.Any())
            {
                ModelState.AddModelError("", "کاربری یافت نشد");
            }
            return View(users);
        }


        public IActionResult Add() => View();
        
        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usr = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                var isExistEmail = await _userManager.FindByEmailAsync(model.Email) != null;
                var isExistUserName = await _userManager.FindByNameAsync(model.UserName) != null;
                if (!isExistUserName && !isExistEmail)
                {
                    var result = await _userManager.CreateAsync(usr, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(List));
                    }
                    else
                    {
                        AddErrosFromResult(result);
                    }
                }
                else
                {
                    if (isExistUserName)
                    {
                        ModelState.AddModelError("", "این نام کاربری وجود دارد");
                    }
                    if (isExistEmail)
                    {
                        ModelState.AddModelError("", "این ایمیل وجود دارد");
                    }
                }                
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(List));
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            else
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
            }
            return RedirectToAction(nameof(List), new { errors =
                GetErrosFromModelState()});
        }

        public async Task<IActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            if(user != null)
            {
                var updateModel = new UpdateUserViewModel()
                {
                    Email = user.Email,
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                return View(updateModel);
            }
            else
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
            }
            return RedirectToAction(nameof(List), new {
                errors = GetErrosFromModelState() });
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                if (string.IsNullOrEmpty(model.Email) &&
                    string.IsNullOrEmpty(model.Password))
                {
                    ModelState.AddModelError("",
                        "یک فیلد را برای ویرایش پر کنید");
                }
                else
                {
                    IdentityResult validEmail = null;
                    if (!string.IsNullOrEmpty(model.Email))
                    {
                        user.Email = model.Email;
                        validEmail = await _userValidator.ValidateAsync(_userManager, user);
                        if (!validEmail.Succeeded)
                        {
                            AddErrosFromResult(validEmail);
                        }
                    }
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
                            ModelState.AddModelError("", "تکرار کلمه عبور را اشتباه وارد کردید");
                        }
                    }

                    bool isChangedName = false;
                    if (user.FirstName != model.FirstName)
                    {
                        user.FirstName = model.FirstName;
                        isChangedName = true;
                    }
                    if (user.LastName != model.LastName)
                    {
                        user.LastName = model.LastName;
                        isChangedName = true;
                    }


                    if ((validPass != null && validPass.Succeeded) ||
                        (validEmail != null && validEmail.Succeeded) ||
                        isChangedName)
                    {
                        var result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(List));
                        }
                        else
                        {
                            AddErrosFromResult(result);
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
            }
            model.UserName = user.UserName;
            return View(model);
        }
                
        public async Task<IActionResult> AddUserToRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                var roles = _roleManager.Roles.ToList();
                if(roles.Any())
                {
                    var userRoles = _userManager.GetRolesAsync(user).Result.ToList();

                    var addRoleModel = new AddUserToRoleViewModel()
                    {
                        UserName = user.UserName,
                        RolesName = new List<string>(),
                    };
                    foreach (var item in roles)
                    {
                        if (!userRoles.Contains(item.Name))
                        {
                            addRoleModel.AllRoles.Add(item.Name);
                        }
                    }
                    return View(addRoleModel);
                }
                else
                {
                    ModelState.AddModelError("", "نقشی وجود ندارد! ابتدا نقش اضافه کنید");
                }
            }
            else
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
            }
            return RedirectToAction(nameof(List), new
            {
                errors = GetErrosFromModelState()
            });
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRoles(AddUserToRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    foreach (var item in model.RolesName)
                    {
                        var role = await _roleManager.FindByNameAsync(item);
                        if (role != null)
                        {
                            var result = await _userManager.AddToRoleAsync(user, role.Name);
                            if (!result.Succeeded)
                            {
                                AddErrosFromResult(result);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", $"'{item}' یافت نشد");
                        }
                    }
                    if (ModelState.IsValid)
                    {
                        return RedirectToAction(nameof(List));
                    }
                }
                else
                {
                    ModelState.AddModelError("", "کاربر یافت نشد");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async  Task<IActionResult> RemoveRoleFromUser(RemoveRoleFromUserViewModel model)
        {
            var user = _userManager.FindByIdAsync(model.UserId).Result;
            if (user != null)
            {
                var role = _roleManager.FindByNameAsync(model.RoleName).Result;
                if (role != null)
                {
                    var result = await _userManager.RemoveFromRoleAsync(user, 
                        role.Name);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(GetUserRoles),
                            new { userName = user.UserName });
                    }
                    else
                    {
                        AddErrosFromResult(result);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "نقش یافت نشد");
                }
            }
            else
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
                return RedirectToAction(nameof(List),
                            new
                            {
                                errors = GetErrosFromModelState()
                            });
            }
            return RedirectToAction(nameof(GetUserRoles),
                            new { userName = user.UserName ,
                            errors = GetErrosFromModelState() });
        }

        public async Task<IActionResult> GetUserRoles(
            string userName, List<string> errors = null)
        {
            AddErrosToModelState(errors);

            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                var roles = _userManager.GetRolesAsync(user)
                    .Result.ToList();
                var model = new GetUserRoelsViewModel()
                {
                    RolesName = roles,
                    UserName = user.UserName,
                    UserId = user.Id
                };
                if(roles.Any())
                {
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("", "کاربر نقشی ندارد");
                }                                
            }
            else
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
            }
            return View(new GetUserRoelsViewModel() { UserName = userName });
        }






        private List<string> GetErrosFromModelState()
        {
            var modelErrors = new List<string>();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Add(modelError.ErrorMessage);
                    }
                }
            }
            return modelErrors;
        }
        private void AddErrosToModelState(List<string> errors)
        {
            if (errors != null)
            {
                foreach (var err in errors)
                {
                    ModelState.AddModelError("", err);
                }
            }
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
